using Volo.Abp.Modularity;

namespace LogCloud;

[DependsOn(
    typeof(LogCloudApplicationModule),
    typeof(LogCloudDomainTestModule)
)]
public class LogCloudApplicationTestModule : AbpModule
{

}
