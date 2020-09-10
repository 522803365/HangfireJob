using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ControlCenterServices.Application
{
    [DependsOn(
       
        typeof(AbpIdentityApplicationModule) 
        )]
    public class ControlCenterServicesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
 
        }
    }
}
