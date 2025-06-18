using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LogCloud.Data;
using Volo.Abp.DependencyInjection;

namespace LogCloud.EntityFrameworkCore;

public class EntityFrameworkCoreLogCloudDbSchemaMigrator
    : ILogCloudDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLogCloudDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LogCloudDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LogCloudDbContext>()
            .Database
            .MigrateAsync();
    }
}
