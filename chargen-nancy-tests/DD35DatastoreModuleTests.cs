using System.Threading.Tasks;
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
            var browser = new Browser(bootstrapper);

            var result = await browser.Get("/DD35", with => { with.HttpsRequest(); });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}