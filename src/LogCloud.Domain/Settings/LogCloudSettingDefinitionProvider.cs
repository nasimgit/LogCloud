using Volo.Abp.Settings;

namespace LogCloud.Settings;

public class LogCloudSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LogCloudSettings.MySetting1));
    }
}
