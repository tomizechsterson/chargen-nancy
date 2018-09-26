using System.Threading.Tasks;
using chargen_nancy.Modules.DD35;
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
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(with => with.Module(new DD35DatastoreModule(":memory:")));

            var result = await browser.Get("/DD35", with => { with.HttpsRequest(); });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}