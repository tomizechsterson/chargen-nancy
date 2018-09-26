using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace chargen_nancy_dd35.Datastore
{
    public class DD35SqliteCharacters : DD35Characters
    {
        private readonly string _dbName;
        private readonly SqliteConnection _testConnection;

        public DD35SqliteCharacters(string dbName)
        {
            _dbName = dbName;
        }

        public DD35SqliteCharacters(SqliteConnection testConnection)
        {
            if (testConnection.ConnectionString == null)
                _dbName = "characters";

            _testConnection = testConnection;
        }
        
        public async Task<CharacterModel[]> Get()
        {
            if (_testConnection?.ConnectionString != null)
                return await Get(_testConnection);

            using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                return await Get(conn);
        }

        public async Task<CharacterModel> Get(long id)
        {
            if (_testConnection?.ConnectionString != null)
                return await Get(id, _testConnection);

            using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                return await Get(id, conn);
        }

        public async Task<long> Add(CharacterModel model)
        {
            if (_testConnection?.ConnectionString != null)
                return await Add(model, _testConnection);

            using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                return await Add(model, conn);
        }

        public async Task Update(long id, CharacterModel model)
        {
            if (_testConnection?.ConnectionString != null)
                await Update(id, model, _testConnection);
            else
            {
                using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                    await Update(id, model, conn);
            }
        }

        public async Task Delete(long id)
        {
            if (_testConnection?.ConnectionString != null)
                await Delete(id, _testConnection);
            else
            {
                using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                    await Delete(id, conn);
            }
        }

        private static async Task<CharacterModel[]> Get(SqliteConnection connection)
        {
            var results = new List<CharacterModel>();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DD35";
            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    results.Add(new CharacterModel
                    {
                        Id = await reader.GetFieldValueAsync<int>(0),
                        Name = await reader.GetFieldValueAsync<string>(1)
                    });
                }
            }

            return results.ToArray();
        }

        private static async Task<CharacterModel> Get(long id, SqliteConnection connection)
        {
            var result = new CharacterModel {Name = "none"};
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DD35 " +
                                  "WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id.ToString());
            await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Id = await reader.GetFieldValueAsync<int>(0);
                    result.Name = await reader.GetFieldValueAsync<string>(1);
                }
            }

            return result;
        }

        private static async Task<long> Add(CharacterModel model, SqliteConnection connection)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO DD35 (Name) " +
                                      "VALUES ($name)";
                command.Parameters.AddWithValue("$name", model.Name);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                command = connection.CreateCommand();
                command.CommandText = "SELECT last_insert_rowid()";
                await connection.OpenAsync();
                return (long) await command.ExecuteScalarAsync();
            }
            catch (SqliteException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static async Task Update(long id, CharacterModel model, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE DD35 SET Name = $name " +
                                  "WHERE Id = $id";
            command.Parameters.AddWithValue("$name", model.Name);
            command.Parameters.AddWithValue("$id", id.ToString());
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        private static async Task Delete(long id, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM DD35 WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id.ToString());
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}