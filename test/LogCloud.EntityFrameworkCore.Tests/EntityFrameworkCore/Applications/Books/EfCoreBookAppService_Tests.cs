using LogCloud.Books;
using Xunit;

namespace LogCloud.EntityFrameworkCore.Applications.Books;

[Collection(LogCloudTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<LogCloudEntityFrameworkCoreTestModule>
{

}