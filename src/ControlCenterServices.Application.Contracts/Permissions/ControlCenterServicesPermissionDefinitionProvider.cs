
using ControlCenterServices.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ControlCenterServices.Application.Contracts.Permissions
{
    public class ControlCenterServicesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ControlCenterServicesPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ControlCenterServicesPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ControlCenterServicesResource>(name);
        }
    }
}
