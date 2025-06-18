using Xunit;

namespace LogCloud.EntityFrameworkCore;

[CollectionDefinition(LogCloudTestConsts.CollectionDefinitionName)]
public class LogCloudEntityFrameworkCoreCollection : ICollectionFixture<LogCloudEntityFrameworkCoreFixture>
{

}
