using Volo.Abp.Modularity;

namespace LogCloud;

[DependsOn(
    typeof(LogCloudDomainModule),
    typeof(LogCloudTestBaseModule)
)]
public class LogCloudDomainTestModule : AbpModule
{

}
