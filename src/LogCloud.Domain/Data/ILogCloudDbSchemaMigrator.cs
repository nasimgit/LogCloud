using System.Threading.Tasks;

namespace LogCloud.Data;

public interface ILogCloudDbSchemaMigrator
{
    Task MigrateAsync();
}
