using BagOfHolding.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagOfHolding.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "BagOfHolding.db");
            _connectionString = $"Data Source={dbPath}";

            InitializeDatabase();
        }

        //creates fresh connection while making it so I do not need to call the full connection name every time.
        private IDbConnection CreateConnection() => new SqliteConnection(_connectionString);

        private void InitializeDatabase()
        {
            using var connection = CreateConnection();
            connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Players (
                PlayerId INTEGER PRIMARY KEY AUTOINCREMENT,
                PlayerName TEXT NOT NULL
            );");
        }

        public async Task<IEnumerable<PlayerModel>> GetPlayers()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<PlayerModel>("SELECT * FROM Players");
        }
    }
}
