using System.Threading.Tasks;
using chargen_nancy_dd35.Datastore;
using Xunit;

namespace chargen_nancy_tests
{
    public class DD35SqliteTests
    {
        private readonly DD35SqliteCharacters _db;

        public DD35SqliteTests()
        {
            var dbSetup = new SqliteDbSetup("DataSource=:memory:");
            var testConnection = dbSetup.TestConnection;
            dbSetup.CreateTables();
            _db = new DD35SqliteCharacters(testConnection.ConnectionString);
        }

        [Fact]
        public async Task GetAll()
        {
            await _db.Add(new CharacterModel {Name = "first"});
            await _db.Add(new CharacterModel {Name = "second"});

            var results = await _db.Get();

            Assert.Equal(2, results.Length);
        }
    }
}