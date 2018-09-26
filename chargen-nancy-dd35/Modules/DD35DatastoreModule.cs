using System.Collections.Generic;
using chargen_nancy_dd35.Datastore;
using Nancy;

namespace chargen_nancy.Modules.DD35
{
    public sealed class DD35DatastoreModule : NancyModule
    {
        public DD35DatastoreModule(DD35Characters storage = null)
        {
            var db = storage ?? new DD35SqliteCharacters("DataSource=characters");

            Get("/", args => new List<CharacterModel> {CharacterModel.NullModel(), CharacterModel.NullModel()});
            Get("/{id:int}", async args => CharacterModel.NullModel());
            Post("/", async args => -1);
            Put("/{id:int}", args => -1);
            Delete("/{id:int}", args => -1);
        }
    }
}