using KeibaAiDataImporter.App.Controls;
using KeibaAiDataImporter.Core.Entities;
using KeibaAiDataImporter.Core.Generators;
using KeibaAiDataImporter.Infrastructure.Database;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

#nullable enable

namespace KeibaAiDataImporter.App
{
    // ファイル区切り通知用のEntity
    public class EndOfFileEntity : JvEntity
    {
        public override void SetData(byte[] buffer) { }
    }

    // データ種別の終端通知＆DB保存完了待機用Entity
    public class EndOfSpecEntity : JvEntity
    {
        public string DataSpec { get; }
        public int CompletedFiles { get; }
        public TaskCompletionSource<bool> Completion { get; }

        public EndOfSpecEntity(string dataSpec, int completedFiles, TaskCompletionSource<bool> completion)
        {
            DataSpec = dataSpec;
            CompletedFiles = completedFiles;
            Completion = completion;
        }

        public override void SetData(byte[] buffer) { }
    }

    public partial class Form1 : Form
    {
        // JV-Link ActiveX (COMが利用できない場合null)
        private AxJVDTLabLib.AxJVLink? axJVLink1;

        // UIコントロール
        private Button btnDbSetup = null!;
        private Button btnStart = null!;
        private Button btnStop = null!;
        private Button btnSelectAll = null!;
        private Button btnDeselectAll = null!;
        private TextBox txtLog = null!;
        private ProgressBar progressBar1 = null!;
        private Label lblProgress = null!;
        private TimelinePanel timelinePanel = null!;

        // 処理制御用
        private CancellationTokenSource? _cts;
        private BlockingCollection<JvEntity> _queue = null!;

        // 辞書
        private Dictionary<string, string> _tableMap = new();
        private Dictionary<string, Type> _entityTypeMap = new();

        // 履歴管理用
        private Dictionary<string, string> _fetchHistory = new();
        private const string HISTORY_FILE = "fetch_history.json";

        // 取得対象のデータスペック一覧
        private static readonly string[] AllSpecs =
        {
            "RACE", "DIFN", "BLDN", "MING", "SLOP",
            "COMM", "WOOD", "TOKU", "HOSN", "HOYU", "SNPN", "YSCH"
        };

        // JVLink用変数
        private int _readCount;
        private int _downloadCount;
        private string _lastTimestamp = "";

        public Form1()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeCustomComponents();
            LoadEntityTypes();
            LoadHistory();
        }

        private void LoadHistory()
        {
            _fetchHistory.Clear();
            if (File.Exists(HISTORY_FILE))
            {
                try
                {
                    string json = File.ReadAllText(HISTORY_FILE);
                    _fetchHistory = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                        ?? new Dictionary<string, string>();
                }
                catch (Exception ex)
                {
                    Log($"[警告] 履歴読み込みエラー: {ex.Message}");
                }
            }

            // タイムラインに反映
            timelinePanel?.SetFetchTimestamps(_fetchHistory);
        }

        private void SaveHistory()
        {
            try
            {
                string json = JsonSerializer.Serialize(_fetchHistory, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(HISTORY_FILE, json);
            }
            catch (Exception ex)
            {
                Log($"[警告] 履歴保存エラー: {ex.Message}");
            }
        }

        private void LoadEntityTypes()
        {
            _entityTypeMap = new Dictionary<string, Type>();
            var assembly = typeof(JvEntity).Assembly;
            var types = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(JvEntity)) && !t.IsAbstract);

            foreach (var type in types)
            {
                string name = type.Name.Replace("Entity", "");
                if (name.Length == 2)
                {
                    _entityTypeMap[name] = type;
                }
            }
        }

        private void InitializeCustomComponents()
        {
            this.Text = "KeibaAi Data Importer";
            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(33, 37, 41);
            this.Size = new Size(850, 750);
            this.MinimumSize = new Size(750, 550);
            this.Font = new Font("Segoe UI", 9.5f);

            // JV-Link ActiveX — フォームハンドル生成後に初期化
            try
            {
                _ = this.Handle; // フォームハンドルを強制生成
                axJVLink1 = new AxJVDTLabLib.AxJVLink();
                ((System.ComponentModel.ISupportInitialize)axJVLink1).BeginInit();
                axJVLink1.Name = "axJVLink1";
                axJVLink1.Size = new Size(0, 0);
                axJVLink1.Visible = false;
                this.Controls.Add(axJVLink1);
                ((System.ComponentModel.ISupportInitialize)axJVLink1).EndInit();
            }
            catch (Exception ex)
            {
                axJVLink1 = null;
                Log($"[警告] JV-Link初期化失敗: {ex.Message}");
                Log("  → JV-Link が正しくインストール・登録されているか確認してください");
            }

            int btnY = 15;
            int btnH = 36;
            var btnFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            var btnBg = Color.White;
            var btnFg = Color.FromArgb(33, 37, 41);
            var borderColor = Color.FromArgb(220, 224, 230);

            // ボタン: DBセットアップ
            btnDbSetup = new Button
            {
                Text = "DB Setup",
                Location = new Point(15, btnY),
                Size = new Size(95, btnH),
                FlatStyle = FlatStyle.Flat,
                BackColor = btnBg,
                ForeColor = btnFg,
                Font = btnFont,
                Cursor = Cursors.Hand,
            };
            btnDbSetup.FlatAppearance.BorderColor = borderColor;
            btnDbSetup.FlatAppearance.BorderSize = 1;
            btnDbSetup.Click += BtnDbSetup_Click;
            this.Controls.Add(btnDbSetup);

            // ボタン: データ取込開始
            btnStart = new Button
            {
                Text = "▶ 開始",
                Location = new Point(120, btnY),
                Size = new Size(85, btnH),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(10, 132, 255), // Modern Blue
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);

            // ボタン: 停止
            btnStop = new Button
            {
                Text = "⏹ 停止",
                Location = new Point(215, btnY),
                Size = new Size(85, btnH),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 59, 48), // Modern Red
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Enabled = false,
            };
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.Click += (s, e) => _cts?.Cancel();
            this.Controls.Add(btnStop);

            // ボタン: 全選択
            btnSelectAll = new Button
            {
                Text = "全選択",
                Location = new Point(320, btnY),
                Size = new Size(70, btnH),
                FlatStyle = FlatStyle.Flat,
                BackColor = btnBg,
                ForeColor = btnFg,
                Font = btnFont,
                Cursor = Cursors.Hand,
            };
            btnSelectAll.FlatAppearance.BorderColor = borderColor;
            btnSelectAll.Click += (s, e) => timelinePanel.SelectAll();
            this.Controls.Add(btnSelectAll);

            // ボタン: 全解除
            btnDeselectAll = new Button
            {
                Text = "全解除",
                Location = new Point(400, btnY),
                Size = new Size(70, btnH),
                FlatStyle = FlatStyle.Flat,
                BackColor = btnBg,
                ForeColor = btnFg,
                Font = btnFont,
                Cursor = Cursors.Hand,
            };
            btnDeselectAll.FlatAppearance.BorderColor = borderColor;
            btnDeselectAll.Click += (s, e) => timelinePanel.DeselectAll();
            this.Controls.Add(btnDeselectAll);

            // タイムラインパネル
            timelinePanel = new TimelinePanel(AllSpecs)
            {
                Location = new Point(15, btnY + btnH + 15),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };
            timelinePanel.Size = new Size(this.ClientSize.Width - 30, AllSpecs.Length * 32 + 5);
            this.Controls.Add(timelinePanel);

            int timelineBottom = timelinePanel.Bottom + 10;

            // ラベル: 進捗
            lblProgress = new Label
            {
                Text = "待機中",
                Location = new Point(15, timelineBottom),
                Size = new Size(this.ClientSize.Width - 30, 20),
                ForeColor = Color.FromArgb(100, 100, 110),
                Font = new Font("Segoe UI", 9f),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };
            this.Controls.Add(lblProgress);

            // プログレスバー
            progressBar1 = new ProgressBar
            {
                Location = new Point(15, timelineBottom + 25),
                Size = new Size(this.ClientSize.Width - 30, 6), // Thin modern progress bar
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Style = ProgressBarStyle.Continuous
            };
            this.Controls.Add(progressBar1);

            // ログパネル (背景を白くして、角丸っぽく見せるためにパディングを持たせる)
            Panel logContainer = new Panel
            {
                Location = new Point(15, timelineBottom + 45),
                Size = new Size(this.ClientSize.Width - 30, this.ClientSize.Height - timelineBottom - 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.FromArgb(249, 250, 251),
                Padding = new Padding(10), // Inner padding
            };

            // ログ
            txtLog = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.FromArgb(249, 250, 251),
                ForeColor = Color.FromArgb(33, 37, 41),
                Font = new Font("Consolas", 9.5f),
                BorderStyle = BorderStyle.None,
            };
            logContainer.Controls.Add(txtLog);
            this.Controls.Add(logContainer);
        }

        // ========== DBセットアップ ==========
        private async void BtnDbSetup_Click(object? sender, EventArgs e)
        {
            btnDbSetup.Enabled = false;
            try
            {
                Log("JVData_Struct.cs 解析中...");
                string structPath = Path.Combine(AppContext.BaseDirectory, "JVData_Struct.cs");
                if (!File.Exists(structPath))
                {
                    structPath = Path.Combine(Directory.GetCurrentDirectory(), "JVData_Struct.cs");
                }
                if (!File.Exists(structPath))
                {
                    Log("[エラー] JVData_Struct.cs が見つかりません。");
                    return;
                }

                var parser = new JvStructParser();
                var structs = parser.Parse(structPath);
                Log($"  → {structs.Count} 構造体を検出");

                // テーブルマッピング自動生成
                var mapGen = new TableIdMapGenerator();
                _tableMap = mapGen.GenerateMap(structs);
                Log($"  → {_tableMap.Count} テーブルマップ生成");

                // DDL生成
                var ddlGen = new SqlDdlGenerator();
                string ddl = ddlGen.GenerateDdl(structs);
                Log($"  → DDL生成完了 ({ddl.Length} 文字)");

                // DDLをファイルに保存（デバッグ用）
                File.WriteAllText("generated_ddl.sql", ddl);
                Log("  → generated_ddl.sql に保存");

                // スキーマ初期化
                Log("PostgreSQL にスキーマ作成中...");
                await Task.Run(() =>
                {
                    var initializer = new SchemaInitializer();
                    initializer.InitializeSchema(ddl);
                });
                Log("✅ テーブル作成完了");

                // AI用計算列の追加
                Log("AI用計算列を生成中...");
                var computedGen = new ComputedColumnGenerator();
                string computedSql = computedGen.GenerateComputedColumns(structs);
                File.WriteAllText("generated_computed_columns.sql", computedSql);
                Log($"  → generated_computed_columns.sql に保存 ({computedSql.Length} 文字)");

                await Task.Run(() =>
                {
                    var initializer = new SchemaInitializer();
                    var results = initializer.InitializeSchemaStatements(computedSql);
                    int successCount = results.Count(r => r.Success);
                    int failCount = results.Count(r => !r.Success);

                    this.BeginInvoke((Action)(() =>
                    {
                        foreach (var r in results.Where(r => !r.Success))
                        {
                            Log($"  [警告] SQL失敗: {r.Error}");
                            Log($"    → {r.Statement[..Math.Min(r.Statement.Length, 100)]}");
                        }
                        Log($"  計算列: 成功={successCount}, 失敗={failCount}");
                    }));
                });
                Log("✅ DBセットアップ完了（計算列・インデックス含む）");
            }
            catch (Exception ex)
            {
                Log($"[エラー] DBセットアップ失敗: {ex.Message}");
            }
            finally
            {
                btnDbSetup.Enabled = true;
            }
        }

        // ========== データ取込開始 ==========
        private async void BtnStart_Click(object? sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnDbSetup.Enabled = false;

            try
            {
                // テーブルマップが未生成なら自動生成
                if (_tableMap.Count == 0)
                {
                    Log("テーブルマップ自動生成中...");
                    string structPath = Path.Combine(AppContext.BaseDirectory, "JVData_Struct.cs");
                    if (!File.Exists(structPath))
                        structPath = Path.Combine(Directory.GetCurrentDirectory(), "JVData_Struct.cs");

                    if (File.Exists(structPath))
                    {
                        var parser = new JvStructParser();
                        var structs = parser.Parse(structPath);
                        var mapGen = new TableIdMapGenerator();
                        _tableMap = mapGen.GenerateMap(structs);
                        Log($"  → {_tableMap.Count} テーブルマップ生成");
                    }
                    else
                    {
                        Log("[エラー] JVData_Struct.cs が見つかりません。");
                        return;
                    }
                }

                if (axJVLink1 == null)
                {
                    Log("[エラー] JV-Linkが初期化されていません。JV-Linkが正しくインストールされているか確認してください。");
                    return;
                }

                int initCode = axJVLink1.JVInit("UNKNOWN");
                if (initCode != 0)
                {
                    Log($"JVInit Error: {initCode}");
                    return;
                }

                _cts = new CancellationTokenSource();
                _queue = new BlockingCollection<JvEntity>(10000);

                var consumerTask = Task.Run(() => ConsumerLoop(_queue, _cts.Token));

                try
                {
                    await ProcessAllSpecsAsync();
                }
                catch (Exception ex)
                {
                    Log($"[Fatal Error] {ex.Message}");
                }
                finally
                {
                    _queue.CompleteAdding();

                    try { await consumerTask; }
                    catch (Exception ex) { Log($"Consumer Task Error: {ex.Message}"); }

                    axJVLink1.JVClose();
                    Log("全処理完了");
                }
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnDbSetup.Enabled = true;

                timelinePanel.SetActiveSpec(null);
                lblProgress.Text = "待機中";

                if (_cts != null)
                {
                    _cts.Dispose();
                    _cts = null;
                }
            }
        }

        private async Task ProcessAllSpecsAsync()
        {
            // チェックボックスで選択されたスペックのみ処理
            var selectedSpecs = timelinePanel.GetSelectedSpecs().ToList();
            Log($"選択されたデータスペック: {string.Join(", ", selectedSpecs)}");

            foreach (var spec in selectedSpecs)
            {
                if (_cts?.IsCancellationRequested == true) break;

                await ProcessSingleSpec(spec);

                Log("...次のデータ種別まで待機中(3秒)...");
                await Task.Delay(3000);
            }
        }

        private async Task ProcessSingleSpec(string dataspec)
        {
            // タイムラインを更新
            timelinePanel.SetActiveSpec(dataspec);

            string fromTime;
            int option;

            if (_fetchHistory.TryGetValue(dataspec, out string? lastTime) && !string.IsNullOrEmpty(lastTime))
            {
                fromTime = lastTime;
                option = 1; // 続きから
                Log($"--- [{dataspec}] 更新 (Opt=1, From={fromTime}) ---");
            }
            else
            {
                fromTime = "20000101000000";
                option = 4; // ★最適化5: ダイアログ無しセットアップ
                Log($"--- [{dataspec}] 初回セットアップ (Opt=4, From={fromTime}) ---");
            }

            int ret = -1;
            int maxRetries = 3;
            _readCount = 0;
            _downloadCount = 0;
            _lastTimestamp = "";

            for (int i = 1; i <= maxRetries; i++)
            {
                if (_cts?.IsCancellationRequested == true) return;

                _readCount = 0;
                _downloadCount = 0;

                Log($"[{dataspec}] JVOpen 試行 {i}/{maxRetries}");
                ret = axJVLink1.JVOpen(dataspec, fromTime, option, ref _readCount, ref _downloadCount, out _lastTimestamp);

                if (ret == 0) break;

                Log($"[Retry] JVOpenエラー({ret})。1秒待機して再試行...");
                await Task.Delay(1000);
            }

            if (ret != 0)
            {
                Log($"[Fatal] {dataspec}: JVOpen失敗。スキップします。(Code={ret})");
                return;
            }

            if (_downloadCount <= 0 && _readCount <= 0)
            {
                Log($"[{dataspec}] 更新データはありません。");
                if (!string.IsNullOrEmpty(_lastTimestamp))
                {
                    _fetchHistory[dataspec] = _lastTimestamp;
                    SaveHistory();
                    timelinePanel.UpdateTimestamp(dataspec, _lastTimestamp);
                    Log($"[{dataspec}] 次回開始位置を更新しました: {_lastTimestamp}");
                }
                return;
            }

            Log($"[{dataspec}] 読込対象: {_readCount} ファイル, DL対象: {_downloadCount} ファイル");

            // ★最適化2: JVStatus ポーリングでDL完了を待つ
            if (_downloadCount > 0)
            {
                Log($"[{dataspec}] ダウンロード待機中...");
                while (true)
                {
                    if (_cts?.IsCancellationRequested == true) return;

                    int status = axJVLink1.JVStatus();
                    if (status < 0)
                    {
                        Log($"[{dataspec}] JVStatusエラー: {status}");
                        break;
                    }
                    if (status >= _downloadCount)
                    {
                        Log($"[{dataspec}] ダウンロード完了");
                        break;
                    }

                    // UIに進捗表示
                    double dlProgress = (double)status / _downloadCount;
                    lblProgress.Text = $"[{dataspec}] ダウンロード中... {status}/{_downloadCount} ({dlProgress:P0})";
                    timelinePanel.SetActiveSpec(dataspec, dlProgress * 0.3); // DLは全体の30%とみなす

                    await Task.Delay(500);
                }
            }

            // ★最適化4: readCount ベースのプログレスバー
            progressBar1.Maximum = _readCount > 0 ? _readCount : _downloadCount;
            progressBar1.Value = 0;

            var token = _cts?.Token ?? CancellationToken.None;
            bool isSuccess = true;
            int completedFiles = 0;

            try
            {
                // ★最適化1: JVGets を使用（JVReadの代わり）
                while (!token.IsCancellationRequested)
                {
                    string? strBuff;
                    string filename = "";
                    int size = 110000;

                    // ★ JVReadに変更（JVGetsでのCOM例外回避）
                    int readRes = axJVLink1.JVRead(out strBuff, out size, out filename);

                    if (readRes == 0) // 完了
                    {
                        break;
                    }
                    else if (readRes == -1) // ファイル区切り
                    {
                        SafeEnqueue(new EndOfFileEntity(), token);
                        completedFiles++;

                        // プログレスバー更新
                        if (progressBar1.Value < progressBar1.Maximum)
                        {
                            progressBar1.Value = Math.Min(completedFiles, progressBar1.Maximum);
                        }

                        double fileProgress = 0.3 + 0.7 * ((double)completedFiles / progressBar1.Maximum);
                        timelinePanel.SetActiveSpec(dataspec, fileProgress);
                        lblProgress.Text = $"[{dataspec}] 読込中... {completedFiles}/{progressBar1.Maximum} ファイル";

                        Application.DoEvents();
                        continue;
                    }
                    else if (readRes == -3) // ダウンロード待機
                    {
                        await Task.Delay(200);
                        continue;
                    }
                    else if (readRes < 0) // エラー
                    {
                        Log($"JVRead Error: {readRes}");
                        isSuccess = false;
                        break;
                    }
                    else if (readRes > 0 && !string.IsNullOrEmpty(strBuff)) // データあり
                    {
                        if (strBuff.Length >= 2)
                        {
                            string id = strBuff.Substring(0, 2);

                            if (_entityTypeMap.TryGetValue(id, out Type? entityType) && entityType != null)
                            {
                                var sjis = Encoding.GetEncoding("Shift_JIS");
                                byte[] bytData = sjis.GetBytes(strBuff);

                                var entity = (JvEntity?)Activator.CreateInstance(entityType);
                                if (entity != null)
                                {
                                    entity.SetData(bytData);
                                    SafeEnqueue(entity, token);
                                }
                            }
                            else
                            {
                                // ★最適化3: JVSkip — 不要レコード種別をスキップ
                                axJVLink1.JVSkip();
                            }
                        }
                    }

                    if (DateTime.Now.Millisecond % 50 == 0) Application.DoEvents();
                }

                if (!token.IsCancellationRequested)
                {
                    var completion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    SafeEnqueue(new EndOfSpecEntity(dataspec, completedFiles, completion), token);
                    await completion.Task;
                }
            }
            finally
            {
                axJVLink1.JVClose();
            }

            if (isSuccess && !token.IsCancellationRequested && !string.IsNullOrEmpty(_lastTimestamp))
            {
                _fetchHistory[dataspec] = _lastTimestamp;
                SaveHistory();
                timelinePanel.UpdateTimestamp(dataspec, _lastTimestamp);
                timelinePanel.SetActiveSpec(null);
                Log($"[{dataspec}] 完了。次回開始位置を保存: {_lastTimestamp}");
            }
            else
            {
                timelinePanel.SetActiveSpec(null);
                Log($"[{dataspec}] 中断またはエラーのため、履歴は更新されません。");
            }
        }

        private void SafeEnqueue(JvEntity entity, CancellationToken token)
        {
            while (!_queue.TryAdd(entity, 10))
            {
                Application.DoEvents();
                if (token.IsCancellationRequested) return;
            }
        }

        private void ConsumerLoop(BlockingCollection<JvEntity> queue, CancellationToken token)
        {
            var buffer = new List<JvEntity>();
            var sw = Stopwatch.StartNew();

            try
            {
                foreach (var item in queue.GetConsumingEnumerable(token))
                {
                    if (item is EndOfFileEntity)
                    {
                        if (buffer.Count > 0)
                        {
                            SaveBuffer(buffer);
                            buffer.Clear();
                            sw.Restart();
                        }
                        continue;
                    }

                    if (item is EndOfSpecEntity endOfSpec)
                    {
                        if (buffer.Count > 0)
                        {
                            SaveBuffer(buffer);
                            buffer.Clear();
                            sw.Restart();
                        }

                        this.BeginInvoke((Action)(() =>
                        {
                            progressBar1.Value = progressBar1.Maximum;
                            Log($"[{endOfSpec.DataSpec}] DB保存完了 ({endOfSpec.CompletedFiles} ファイル)");
                        }));

                        endOfSpec.Completion.TrySetResult(true);
                        continue;
                    }

                    buffer.Add(item);

                    if (buffer.Count >= 2000 || sw.ElapsedMilliseconds > 1000)
                    {
                        SaveBuffer(buffer);
                        buffer.Clear();
                        sw.Restart();
                    }
                }

                if (buffer.Count > 0) SaveBuffer(buffer);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                this.BeginInvoke((Action)(() => Log($"DB Fatal Error: {ex.Message}")));
            }
        }

        private void SaveBuffer(List<JvEntity> buffer)
        {
            var groups = buffer.GroupBy(e => e.GetType());

            foreach (var group in groups)
            {
                Type type = group.Key;
                string id = type.Name.Replace("Entity", "").Substring(0, 2).ToUpper();

                if (!_tableMap.TryGetValue(id, out string? tableName) || tableName == null)
                {
                    continue;
                }

                try
                {
                    var importerType = typeof(GenericJvImporter<>).MakeGenericType(type);
                    var importer = Activator.CreateInstance(importerType, tableName, (string[]?)null);

                    if (importer != null)
                    {
                        var method = importerType.GetMethod("ImportWithMerge");
                        var castMethod = typeof(Enumerable).GetMethod("Cast")?.MakeGenericMethod(type);
                        var toListMethod = typeof(Enumerable).GetMethod("ToList")?.MakeGenericMethod(type);

                        if (method != null && castMethod != null && toListMethod != null)
                        {
                            var castedEnumerable = castMethod.Invoke(null, new object[] { group });
                            var castedList = toListMethod.Invoke(null, new object[] { castedEnumerable! });
                            method.Invoke(importer, new object[] { castedList! });
                        }
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.InnerException?.Message ?? ex.Message;
                    Debug.WriteLine($"[DB Error] {type.Name}: {err}");
                    this.BeginInvoke((Action)(() => Log($"DB Error: {type.Name} - {err}")));
                }
            }

            int count = buffer.Count;
            this.BeginInvoke((Action)(() => Log($"Saved {count} records.")));
        }

        private void Log(string msg)
        {
            if (txtLog == null || txtLog.IsDisposed) return;

            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke((Action)(() => Log(msg)));
            }
            else
            {
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\r\n");
            }
        }
    }
}
