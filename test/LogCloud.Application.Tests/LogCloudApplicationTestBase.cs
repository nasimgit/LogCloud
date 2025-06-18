using Volo.Abp.Modularity;

namespace LogCloud;

public abstract class LogCloudApplicationTestBase<TStartupModule> : LogCloudTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
