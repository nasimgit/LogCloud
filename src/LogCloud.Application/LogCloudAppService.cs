using LogCloud.Localization;
using Volo.Abp.Application.Services;

namespace LogCloud;

/* Inherit your application services from this class.
 */
public abstract class LogCloudAppService : ApplicationService
{
    protected LogCloudAppService()
    {
        LocalizationResource = typeof(LogCloudResource);
    }
}
