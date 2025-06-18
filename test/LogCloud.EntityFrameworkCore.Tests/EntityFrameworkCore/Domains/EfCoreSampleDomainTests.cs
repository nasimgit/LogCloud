using LogCloud.Samples;
using Xunit;

namespace LogCloud.EntityFrameworkCore.Domains;

[Collection(LogCloudTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<LogCloudEntityFrameworkCoreTestModule>
{

}
