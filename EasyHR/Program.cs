using EasyHR.Background_Tasks;
using EasyHR.Data;
using EasyHR.Models;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHR
{
    public class Program
    {
        public static async Task Main(string[] args) => (await CreateHostBuilder(args).Build().SeedDbAsync()).Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                 .ConfigureServices(services =>
                    services.AddHostedService<BackgroundTasker>());
    }
}