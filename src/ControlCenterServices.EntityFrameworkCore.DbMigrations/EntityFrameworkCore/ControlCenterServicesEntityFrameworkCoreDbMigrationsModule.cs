using ControlCenterServices.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ControlCenterServices.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(ControlCenterServicesEntityFrameworkCoreModule)
        )]
    public class ControlCenterServicesEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ControlCenterServicesMigrationsDbContext>();
        }
    }
}
