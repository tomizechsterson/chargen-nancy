using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chargen_nancy.Modules.DD35;
using chargen_nancy_dd35.Datastore;
using Microsoft.Data.Sqlite;
using Nancy.Testing;
using StoryTeller;

namespace chargen_nancy_storyteller.Fixtures
{
    public class DD35StorageFixture : Fixture
    {
        private readonly SqliteConnection _testConnection = new SqliteConnection("DataSource=:memory:");
        private Browser _browser;
        private CharacterModel _character;

        public override void SetUp()
        {
            new SqliteDbSetup(_testConnection).CreateTables();
            _browser = new Browser(with =>
            {
                with.Module<DD35DatastoreModule>();
                with.Dependency(new DD35SqliteCharacters(_testConnection));
            });
        }

        public async Task<int> GetAllAsync()
        {
            var response = await _browser.Get("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });
            
            return response.Body.DeserializeJson<IEnumerable<CharacterModel>>().Count();
        }

        public async Task GetByIdAsync(int id)
        {
            var response = await _browser.Get($"/{id.ToString()}", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });
            _character = response.Body.DeserializeJson<CharacterModel>();
        }

        public async Task InsertNewAsync(string name)
        {
            await _browser.Post("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
                with.JsonBody(new CharacterModel {Name = name});
            });
        }

        public async Task UpdateAsync(int id, string name)
        {
            await _browser.Put($"/{id.ToString()}", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
                with.JsonBody(new CharacterModel {Name = name});
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _browser.Delete($"/{id.ToString()}", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });
        }

        public string CheckName()
        {
            return _character.Name;
        }
    }
}