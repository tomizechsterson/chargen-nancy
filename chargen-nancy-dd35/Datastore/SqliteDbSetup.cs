using Microsoft.Data.Sqlite;

namespace chargen_nancy_dd35.Datastore
{
    public class SqliteDbSetup
    {
        private readonly SqliteConnection _connection;

        public SqliteDbSetup(string connectionString)
        {
            if (connectionString.Contains(":memory:"))
            {
                TestConnection = new SqliteConnection(connectionString);
                _connection = TestConnection;
            }
            else
                _connection = new SqliteConnection(connectionString);
        }

        public SqliteConnection TestConnection { get; }

        public void CreateTables()
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = CreateTableSql();
            _connection.Open();
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