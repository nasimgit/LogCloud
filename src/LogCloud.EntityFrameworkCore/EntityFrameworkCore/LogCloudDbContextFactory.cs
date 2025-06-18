using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LogCloud.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class LogCloudDbContextFactory : IDesignTimeDbContextFactory<LogCloudDbContext>
{
    public LogCloudDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        LogCloudEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<LogCloudDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new LogCloudDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LogCloud.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
