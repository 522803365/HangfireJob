using ControlCenterServices.Application.Contracts;
using ControlCenterServices.EntityFrameworkCore;
using ControlCenterServices.EntityFrameworkCore.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ControlCenterServices.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ControlCenterServicesEntityFrameworkCoreDbMigrationsModule),
        typeof(ControlCenterServicesApplicationContractsModule)
        )]
    public class ControlCenterServicesDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
