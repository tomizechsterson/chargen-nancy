using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace chargen_nancy_dd35.Datastore
{
    public class DD35SqliteCharacters : DD35Characters
    {
        private readonly string _connectionString;

        public DD35SqliteCharacters(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CharacterModel[]> Get()
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                var results = new List<CharacterModel>();

                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM DD35";
                await conn.OpenAsync();
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
        }

        public Task<CharacterModel> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<long> Add(CharacterModel model)
        {
            try
            {
                using (var conn = new SqliteConnection(_connectionString))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "INSERT INTO DD35 (Name) " +
                                          "VALUES ($name)";
                    command.Parameters.AddWithValue("$name", model.Name);
                    await conn.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    command = conn.CreateCommand();
                    command.CommandText = "SELECT last_insert_rowid()";
                    await conn.OpenAsync();
                    return (long) await command.ExecuteScalarAsync();
                }
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