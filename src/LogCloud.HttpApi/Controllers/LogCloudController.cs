using LogCloud.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LogCloud.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LogCloudController : AbpControllerBase
{
    protected LogCloudController()
    {
        LocalizationResource = typeof(LogCloudResource);
    }
}
