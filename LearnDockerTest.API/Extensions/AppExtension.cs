using System.Data.Common;
using LearnDockerTest.API.Data;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Json;

namespace LearnDockerTest.API.Extensions;

public static class AppExtension
{
    public static void SerilogConfiguration(this IHostBuilder host)
    {
        host.UseSerilog((context, loggerConfig) =>
        {
            //loggerConfig.WriteTo.Console();
            //loggerConfig.WriteTo.File(new JsonFormatter(), "logs/applog-.txt", rollingInterval: RollingInterval.Day);
            loggerConfig.ReadFrom.Configuration(context.Configuration);
        });
    }


    public static async void CreateDbIfNotExists(this IHost host)
    {
        

        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();

        //Since we are using custom SQL Image with prepopulated data, we dont need to run the migration here any more
        
        // var pendingMigrations = dbContext.Database.GetPendingMigrations();
        // if (!pendingMigrations.Any())
        // {
        //     await dbContext.Database.MigrateAsync();
        // }
    }
}
