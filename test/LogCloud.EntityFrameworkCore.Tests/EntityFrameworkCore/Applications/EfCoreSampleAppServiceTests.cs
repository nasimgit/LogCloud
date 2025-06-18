using LogCloud.Samples;
using Xunit;

namespace LogCloud.EntityFrameworkCore.Applications;

[Collection(LogCloudTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<LogCloudEntityFrameworkCoreTestModule>
{

}
