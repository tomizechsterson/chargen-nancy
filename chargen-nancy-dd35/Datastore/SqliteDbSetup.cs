using Microsoft.Data.Sqlite;

namespace chargen_nancy_dd35.Datastore
{
    public class SqliteDbSetup
    {
        private readonly string _dbName;
        private readonly SqliteConnection _testConnection;

        public SqliteDbSetup(string dbName)
        {
            _dbName = dbName;
        }

        public SqliteDbSetup(SqliteConnection testConnection)
        {
            _testConnection = testConnection;
        }

        public void CreateTables()
        {
            if (_testConnection != null)
                ExecuteCommand(_testConnection);
            else
            {
                using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                    ExecuteCommand(conn);
            }
        }

        private static void ExecuteCommand(SqliteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = CreateTableSql();
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        private static string CreateTableSql()
        {
            return "CREATE TABLE IF NOT EXISTS DD35 (" +
                   "Id INTEGER PRIMARY KEY NOT NULL, " +
                   "Name VARCHAR(32) NOT NULL, " +
                   "Unique(Name))";
        }
    }
}