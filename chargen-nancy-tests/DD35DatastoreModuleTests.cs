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
        [Fact]
        public async Task Test1Async()
        {
            var browser = new Browser(with =>
            {
                with.Module<DD35DatastoreModule>();
                with.Dependency(new DD35SqliteCharacters(new SqliteConnection("DataSource=:memory:")));
            });

            var response = await browser.Get("/", with =>
            {
                with.HttpsRequest();
                with.Header("Accept", "application/json");
            });

            var model = response.Body.DeserializeJson<IEnumerable<CharacterModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, model.Count());
        }
    }
}