using System.Collections.Generic;
using chargen_nancy.Datastore;
using Nancy;
using Nancy.ModelBinding;

namespace chargen_nancy.Modules
{
    public sealed class ADD2DatastoreModule : NancyModule
    {
        public ADD2DatastoreModule()
        {
            ADD2Characters db = new ADD2SqliteCharacters("Data Source=characters");

            Get("/", async args =>
            {
                var allChars = await db.Iterate();
                var models = new List<HttpCharacterModel>();
                foreach (var character in allChars)
                    models.Add(await character.ToModel());

                return models;
            });

            Get("/{id}", async args => await db.Get(args.id).ToModel());

            Post("/", async args =>
            {
                var model = this.Bind<HttpCharacterModel>();
                await db.Add(model);
            });

            Put("/{id}", async args =>
            {
                var model = this.Bind<HttpCharacterModel>();
                await db.Update(args.id, model);
            });

            Delete("/{id}", async args => { await db.Delete(args.id); });
        }
    }
}