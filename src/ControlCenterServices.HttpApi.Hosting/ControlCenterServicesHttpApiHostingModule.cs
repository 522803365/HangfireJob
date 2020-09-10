

using ControlCenterServices.BackgroundJobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ControlCenterServices.HttpApi.Hosting
{


    [DependsOn(
         typeof(AbpAspNetCoreMvcModule),
         typeof(AbpAutofacModule)
          ,typeof(ControlCenterServicesHttpApiModule)
      )]
    public class ControlCenterServicesHttpApiHostingModule : AbpModule
    {
      /*  public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ////为应用程序配置默认的连接字符串
            //Configure<AbpDbConnectionOptions>(options =>
            //{
            //    options.ConnectionStrings.Default = "......";
            //});



        // context.Services.AddTransient<IHostedService, TestJob>();

        //   context.Services.AddTransient<IHostedService, DataSynchronizationjob>();
            base.ConfigureServices(context);

        }*/
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddTransient<IHostedService, TestJob>();
            base.ConfigureServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            /*
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/

            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 使用HSTS的中间件，该中间件添加了严格传输安全头
            app.UseHsts();

            // 转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // 路由
            app.UseRouting();

            // 跨域
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // 异常处理中间件
            //app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // HTTP => HTTPS
            app.UseHttpsRedirection();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
