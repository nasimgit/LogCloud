using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LogCloud.Data;

/* This is used if database provider does't define
 * ILogCloudDbSchemaMigrator implementation.
 */
public class NullLogCloudDbSchemaMigrator : ILogCloudDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
