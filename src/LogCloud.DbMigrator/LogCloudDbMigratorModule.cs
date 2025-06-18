using LogCloud.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LogCloud.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LogCloudEntityFrameworkCoreModule),
    typeof(LogCloudApplicationContractsModule)
)]
public class LogCloudDbMigratorModule : AbpModule
{
}
