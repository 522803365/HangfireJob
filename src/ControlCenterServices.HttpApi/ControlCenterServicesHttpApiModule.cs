
using ControlCenterServices.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ControlCenterServices.HttpApi
{
    [DependsOn(

          typeof(AbpIdentityHttpApiModule),
        typeof(ControlCenterServicesApplicationModule)

        )]
    public class ControlCenterServicesHttpApiModule : AbpModule
    {
 
    }
}
