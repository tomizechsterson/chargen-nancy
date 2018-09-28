using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace chargen_nancy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>()
                .UseUrls("http://localhost:43000", "https://localhost:43001");
    }
}