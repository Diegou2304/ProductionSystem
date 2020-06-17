﻿

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductionSystem.Web;
using ProductionSystem.Web.Data;

public class Program
{

    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        RunSeeding(host);
        host.Run();
    }

   private static void RunSeeding(IWebHost host)
    {
        var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetService<SeedDb>();
            seeder.SeedAsync().Wait();
        }
    }
    
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
}
