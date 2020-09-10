
using ControlCenterServices.Domain.Configurations;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql.Core;
using Hangfire.PostgreSql;
using Hangfire.SQLite;
using Hangfire.SqlServer;

using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace ControlCenterServices.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class ControlCenterServicesBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {


                switch (AppSettings.EnableDb)
                {
                    case "MySql":
                        config.UseStorage(
                            new MySqlStorage(AppSettings.ConnectionStrings,
                            new MySqlStorageOptions
                            {
                                TablePrefix = "", 
                            })); 
                        break; 
                    case "Sqlite":
                        config.UseSQLiteStorage(AppSettings.ConnectionStrings, new SQLiteStorageOptions
                        {
                            SchemaName = ""
                        });
                        break;

                    case "SqlServer":
                        config.UseSqlServerStorage(AppSettings.ConnectionStrings, new SqlServerStorageOptions
                        {
                            SchemaName = ""
                        });
                        break;

                    case "PostgreSql":
                        config.UsePostgreSqlStorage(AppSettings.ConnectionStrings, new PostgreSqlStorageOptions
                        {
                            SchemaName = ""
                        });
                        break;
                }
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl = false,
                        SslRedirect = false,
                        LoginCaseSensitive = true,
                        Users = new []
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = AppSettings.Hangfire.Login,
                                PasswordClear =  AppSettings.Hangfire.Password
                            }
                        }
                    })
                },
                DashboardTitle = "任务调度中心"
            }); 
            var service = context.ServiceProvider;
            service.UseDataSynchronizationjob();
            //if (AppSettings.EnableDb == "MySql")
            //{
            //    var storage = new MySqlStorage(AppSettings.ConnectionStrings);
            //    service.UseDataSynchronizationjob();
            //}
            //else
            //{
            //    service.UseDataSynchronizationjob();
            //}
             
        }


    }
}
