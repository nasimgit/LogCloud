using Microsoft.Extensions.Localization;
using LogCloud.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LogCloud;

[Dependency(ReplaceServices = true)]
public class LogCloudBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<LogCloudResource> _localizer;

    public LogCloudBrandingProvider(IStringLocalizer<LogCloudResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
