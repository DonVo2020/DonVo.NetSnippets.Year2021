using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DonVo.GraphAPI.Year2021
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
              .CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webHostBuilder =>
                webHostBuilder
                  .UseStartup<Startup>()
                  .ConfigureKestrel(options => options.AllowSynchronousIO = true));
            // TODO: Check. Because of the GraphQL. Their plan is to use the System.Text.Json to allow it async.
        }
    }
}
