using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chargen_nancy.Modules.DD35;
using chargen_nancy_dd35.Datastore;
using Microsoft.Data.Sqlite;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace chargen_nancy_tests
{
    public class DD35DatastoreModuleTests
    {
        private readonly Browser _browser;
        private readonly SqliteConnection _connection;

        public DD35DatastoreModuleTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            new SqliteDbSetup(_connection).CreateTables();
            _browser = new Browser(with =>
            {
                with.Module<DD35DatastoreModule>();
                with.Dependency(new DD35SqliteCharacters(_connection));
            });
        }

        [Fact]
        public async Task GetAsync()
        {
            var response = await _browser.Get("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });

            var model = response.Body.DeserializeJson<IEnumerable<CharacterModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(model);
        }

        [Fact]
        public async Task InsertAsync()
        {
            await _browser.Post("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
                with.JsonBody(new CharacterModel {Name = "test"});
            });

            var response = await _browser.Get("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });

            var model = response.Body.DeserializeJson<IEnumerable<CharacterModel>>().ToArray();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Single(model);
            Assert.Equal("test", model[0].Name);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            await _browser.Post("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
                with.JsonBody(new CharacterModel {Name = "test"});
            });

            await _browser.Put("/1", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
                with.JsonBody(new CharacterModel {Name = "updated"});
            });

            var response = await _browser.Get("/1", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });
            
            var model = response.Body.DeserializeJson<CharacterModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, model.Id);
            Assert.Equal("updated", model.Name);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await _browser.Post("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
                with.JsonBody(new CharacterModel {Name = "delete"});
            });

            await _browser.Delete("/1", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });

            var response = await _browser.Get("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });
            var model = response.Body.DeserializeJson<IEnumerable<CharacterModel>>().ToArray();
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(model);
        }
    }
}