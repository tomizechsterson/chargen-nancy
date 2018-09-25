using Nancy;

namespace chargen_nancy.Modules.DD35
{
    public sealed class DD35DatastoreModule : NancyModule
    {
        public DD35DatastoreModule()
        {
            Get("/DD35", args => "test");
        }
    }
}