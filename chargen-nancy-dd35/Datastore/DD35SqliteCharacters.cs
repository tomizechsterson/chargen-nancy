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
            _testConnection = testConnection;
        }
        
        public async Task<CharacterModel[]> Get()
        {
            if (_testConnection != null)
                return await Get(_testConnection);

            using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                return await Get(conn);
        }

        public async Task<long> Add(CharacterModel model)
        {
            if (_testConnection != null)
                return await Add(model, _testConnection);

            using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                return await Add(model, conn);
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

        public Task<CharacterModel> Get(long id)
        {
            throw new System.NotImplementedException();
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

        public Task Update(long id, CharacterModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}