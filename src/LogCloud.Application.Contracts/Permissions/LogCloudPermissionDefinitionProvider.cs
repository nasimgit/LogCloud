using LogCloud.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace LogCloud.Permissions;

public class LogCloudPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LogCloudPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(LogCloudPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(LogCloudPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(LogCloudPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(LogCloudPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(LogCloudPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LogCloudResource>(name);
    }
}
