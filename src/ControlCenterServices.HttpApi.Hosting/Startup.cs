using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ControlCenterServices.HttpApi.Hosting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApplication<ControlCenterServicesWebModule>();

            //注册服务
            // services.AddApplication<ControlCenterServicesApplicationModule>();
            services.AddApplication<ControlCenterServicesHttpApiHostingModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
