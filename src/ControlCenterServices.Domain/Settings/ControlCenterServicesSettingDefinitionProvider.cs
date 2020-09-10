using Volo.Abp.Settings;

namespace ControlCenterServices.Domain.Settings
{
    public class ControlCenterServicesSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ControlCenterServicesSettings.MySetting1));
        }
    }
}
