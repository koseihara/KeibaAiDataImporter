using dotenv.net;
using Npgsql;
using System;

namespace KeibaAiDataImporter.Infrastructure.Database
{
    public static class DbConnectionFactory
    {
        private static bool _envLoaded;

        public static NpgsqlConnection Create()
        {
            if (!_envLoaded)
            {
                DotEnv.Load(new DotEnvOptions(probeForEnv: true, probeLevelsToSearch: 6));
                _envLoaded = true;
            }

            string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5433";
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "jra_db";
            string username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgre";
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";

            string connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};Timeout=10";

            System.Diagnostics.Debug.WriteLine($"[DB Connection] Host={host}, Port={port}, Database={database}, Username={username}");

            return new NpgsqlConnection(connectionString);
        }
    }
}
