using chargen_nancy_dd35.Datastore;
using Nancy;
using Nancy.ModelBinding;

namespace chargen_nancy.Modules.DD35
{
    public sealed class DD35DatastoreModule : NancyModule
    {
        public DD35DatastoreModule(DD35Characters storage = null)
        {
            var db = storage ?? new DD35SqliteCharacters("DataSource=characters");

            Get("/", async args => await db.Get());
            Get("/{id:int}", async args => await db.Get(args.id));

            Post("/", async args =>
            {
                var model = this.Bind<CharacterModel>();
                await db.Add(model);
            });

            Put("/{id:int}", async args =>
            {
                var model = this.Bind<CharacterModel>();
                await db.Update(args.id, model);
            });

            Delete("/{id:int}", async args => { await db.Delete(args.id); });
        }
    }
}