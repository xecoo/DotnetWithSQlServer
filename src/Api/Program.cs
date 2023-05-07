using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Project.Api
{
    public class Project
    {
        public static void Main(string[] args)
        {            
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}

