namespace KeibaAiDataImporter.App.Controls
{
    /// <summary>
    /// データスペックごとのチェックボックス選択 + 取得状況を表示するコントロール
    /// </summary>
    public class TimelinePanel : UserControl
    {
        private readonly string[] _allSpecs;
        private readonly Dictionary<string, bool> _selectedSpecs = new();
        private readonly Dictionary<string, string> _fetchTimestamps = new();

        private string? _activeSpec;
        private double _activeProgress;

        // 描画定数
        private const int RowHeight = 32;
        private const int CheckboxSize = 18;
        private const int CheckboxLeft = 12;
        private const int LabelLeft = 38;
        private const int LabelWidth = 55;
        private const int StatusLeft = 100;

        // 色定義
        private static readonly Color BgColor = Color.White;
        private static readonly Color TextColor = Color.FromArgb(33, 37, 41);
        private static readonly Color DimTextColor = Color.FromArgb(142, 142, 147);
        private static readonly Color CheckColor = Color.FromArgb(10, 132, 255);
        private static readonly Color ActiveColor = Color.FromArgb(10, 132, 255);
        private static readonly Color CompletedColor = Color.FromArgb(48, 209, 88);
        private static readonly Color CheckboxBorderColor = Color.FromArgb(200, 204, 214);
        private static readonly Color RowAltColor = Color.FromArgb(249, 250, 251);
        private static readonly Color GridColor = Color.FromArgb(235, 235, 240);

        public TimelinePanel(string[] allSpecs)
        {
            _allSpecs = allSpecs;
            foreach (var spec in allSpecs)
                _selectedSpecs[spec] = true;

            this.DoubleBuffered = true;
            this.BackColor = BgColor;
            this.MinimumSize = new Size(300, RowHeight * allSpecs.Length + 5);
        }

        public IEnumerable<string> GetSelectedSpecs()
            => _allSpecs.Where(s => _selectedSpecs.GetValueOrDefault(s, false));

        public void SetFetchTimestamps(Dictionary<string, string> timestamps)
        {
            _fetchTimestamps.Clear();
            foreach (var kvp in timestamps)
                _fetchTimestamps[kvp.Key] = kvp.Value;
            Invalidate();
        }

        public void SetActiveSpec(string? spec, double progress = 0)
        {
            _activeSpec = spec;
            _activeProgress = progress;
            Invalidate();
        }

        public void UpdateTimestamp(string spec, string timestamp)
        {
            _fetchTimestamps[spec] = timestamp;
            Invalidate();
        }

        public void SelectAll()
        {
            foreach (var spec in _allSpecs) _selectedSpecs[spec] = true;
            Invalidate();
        }

        public void DeselectAll()
        {
            foreach (var spec in _allSpecs) _selectedSpecs[spec] = false;
            Invalidate();
        }

        private void FillRoundedRectangle(Graphics g, Brush brush, Rectangle bounds, int cornerRadius)
        {
            using var path = new System.Drawing.Drawing2D.GraphicsPath();
            int arcSize = cornerRadius * 2;
            path.AddArc(bounds.X, bounds.Y, arcSize, arcSize, 180, 90);
            path.AddArc(bounds.Right - arcSize, bounds.Y, arcSize, arcSize, 270, 90);
            path.AddArc(bounds.Right - arcSize, bounds.Bottom - arcSize, arcSize, arcSize, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - arcSize, arcSize, arcSize, 90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }

        private void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle bounds, int cornerRadius)
        {
            using var path = new System.Drawing.Drawing2D.GraphicsPath();
            int arcSize = cornerRadius * 2;
            path.AddArc(bounds.X, bounds.Y, arcSize, arcSize, 180, 90);
            path.AddArc(bounds.Right - arcSize, bounds.Y, arcSize, arcSize, 270, 90);
            path.AddArc(bounds.Right - arcSize, bounds.Bottom - arcSize, arcSize, arcSize, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - arcSize, arcSize, arcSize, 90, 90);
            path.CloseFigure();
            g.DrawPath(pen, path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using var fontLabel = new Font("Consolas", 9.5f, FontStyle.Bold);
            using var fontStatus = new Font("Segoe UI", 9f);
            using var fontStatusBold = new Font("Segoe UI", 9f, FontStyle.Bold);
            using var brushText = new SolidBrush(TextColor);
            using var brushDim = new SolidBrush(DimTextColor);
            using var brushCheck = new SolidBrush(CheckColor);
            using var brushCompleted = new SolidBrush(CompletedColor);
            using var brushActive = new SolidBrush(ActiveColor);
            using var penCheckboxBorder = new Pen(CheckboxBorderColor, 1.5f);
            using var penGrid = new Pen(GridColor, 1f);

            for (int i = 0; i < _allSpecs.Length; i++)
            {
                string spec = _allSpecs[i];
                int y = i * RowHeight;
                bool isSelected = _selectedSpecs.GetValueOrDefault(spec, false);
                bool isActive = spec == _activeSpec;

                // 交互に行背景
                if (i % 2 == 1)
                {
                    using var rowBg = new SolidBrush(RowAltColor);
                    g.FillRectangle(rowBg, 0, y, ClientSize.Width, RowHeight);
                }

                // 取込中ハイライト
                if (isActive)
                {
                    using var activeRowBg = new SolidBrush(Color.FromArgb(20, ActiveColor.R, ActiveColor.G, ActiveColor.B));
                    g.FillRectangle(activeRowBg, 0, y, ClientSize.Width, RowHeight);
                }

                // チェックボックス
                var cbRect = new Rectangle(CheckboxLeft, y + (RowHeight - CheckboxSize) / 2, CheckboxSize, CheckboxSize);
                if (isSelected)
                {
                    FillRoundedRectangle(g, brushCheck, cbRect, 4);
                    using var penCheckWhite = new Pen(Color.White, 2f);
                    g.DrawLine(penCheckWhite,
                        cbRect.X + 4, cbRect.Y + CheckboxSize / 2,
                        cbRect.X + CheckboxSize / 2 - 1, cbRect.Y + CheckboxSize - 5);
                    g.DrawLine(penCheckWhite,
                        cbRect.X + CheckboxSize / 2 - 1, cbRect.Y + CheckboxSize - 5,
                        cbRect.X + CheckboxSize - 4, cbRect.Y + 4);
                }
                else
                {
                    DrawRoundedRectangle(g, penCheckboxBorder, cbRect, 4);
                }

                // スペック名
                g.DrawString(spec, fontLabel, isActive ? brushCheck : brushText,
                    LabelLeft, y + (RowHeight - fontLabel.Height) / 2);

                // 状態表示
                if (isActive)
                {
                    string progressText = _activeProgress > 0
                        ? $"取込中... {_activeProgress:P0}"
                        : "取込中...";
                    g.DrawString(progressText, fontStatusBold, brushActive,
                        StatusLeft, y + (RowHeight - fontStatus.Height) / 2);
                }
                else if (_fetchTimestamps.TryGetValue(spec, out var ts) && TryParseTimestamp(ts, out var fetchDate))
                {
                    string dateStr = fetchDate.ToString("yyyy/MM/dd HH:mm");
                    g.DrawString($"取得済: {dateStr}", fontStatus, brushText,
                        StatusLeft, y + (RowHeight - fontStatus.Height) / 2);
                }
                else
                {
                    g.DrawString("未取得", fontStatus, brushDim,
                        StatusLeft, y + (RowHeight - fontStatus.Height) / 2);
                }

                // 行区切り線
                if (i < _allSpecs.Length - 1)
                    g.DrawLine(penGrid, 0, y + RowHeight - 1, ClientSize.Width, y + RowHeight - 1);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            for (int i = 0; i < _allSpecs.Length; i++)
            {
                int y = i * RowHeight;
                var hitRect = new Rectangle(0, y, LabelLeft + LabelWidth, RowHeight);
                if (hitRect.Contains(e.Location))
                {
                    string spec = _allSpecs[i];
                    _selectedSpecs[spec] = !_selectedSpecs.GetValueOrDefault(spec, false);
                    Invalidate();
                    break;
                }
            }
        }

        private static bool TryParseTimestamp(string ts, out DateTime result)
        {
            result = DateTime.MinValue;
            if (ts.Length < 8) return false;
            return DateTime.TryParseExact(
                ts.Length >= 14 ? ts[..14] : ts[..8],
                ts.Length >= 14 ? "yyyyMMddHHmmss" : "yyyyMMdd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out result);
        }
    }
}
