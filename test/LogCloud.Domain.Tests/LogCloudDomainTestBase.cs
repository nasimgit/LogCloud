using Volo.Abp.Modularity;

namespace LogCloud;

/* Inherit from this class for your domain layer tests. */
public abstract class LogCloudDomainTestBase<TStartupModule> : LogCloudTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
