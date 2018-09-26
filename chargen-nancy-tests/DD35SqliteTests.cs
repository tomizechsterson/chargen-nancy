using System.Threading.Tasks;
using chargen_nancy_dd35.Datastore;
using Microsoft.Data.Sqlite;
using Xunit;

namespace chargen_nancy_tests
{
    public class DD35SqliteTests
    {
        private readonly DD35SqliteCharacters _db;

        public DD35SqliteTests()
        {
            var testConnection = new SqliteConnection("DataSource=:memory:");
            new SqliteDbSetup(testConnection).CreateTables();
            _db = new DD35SqliteCharacters(testConnection);
        }

        [Fact]
        public async Task GetAll()
        {
            await _db.Add(new CharacterModel {Name = "first"});
            await _db.Add(new CharacterModel {Name = "second"});

            var results = await _db.Get();

            Assert.Equal(2, results.Length);
        }

        [Fact]
        public async Task InsertGet()
        {
            await _db.Add(new CharacterModel {Name = "test"});

            var result = await _db.Get(1);

            Assert.Equal(1, result.Id);
            Assert.Equal("test", result.Name);
        }

        [Fact]
        public async Task Update()
        {
            await _db.Add(new CharacterModel {Name = "initial"});
            await _db.Update(1, new CharacterModel {Name = "updated"});

            var result = await _db.Get(1);

            Assert.Equal("updated", result.Name);
        }

        [Fact]
        public async Task Delete()
        {
            await _db.Add(new CharacterModel {Name = "delete"});

            await _db.Delete(1);
            var result = await _db.Get(1);

            Assert.Equal("none", result.Name);
        }
    }
}