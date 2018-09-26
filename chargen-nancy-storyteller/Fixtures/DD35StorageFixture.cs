using chargen_nancy_dd35.Datastore;
using Microsoft.Data.Sqlite;
using Nancy;
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
            
        }

        public void GetById(int id)
        {
            
        }

        public void InsertNew(string name)
        {
            var browser = new Browser(new DefaultNancyBootstrapper());

            browser.Post("/", with =>
            {
                with.HttpsRequest();
                with.Body($"name: {name}", "application/json");
            });
        }
    }
}