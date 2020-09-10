using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ControlCenterServices.Domain.Data
{
    /* This is used if database provider does't define
     * IControlCenterServicesDbSchemaMigrator implementation.
     */
    public class NullControlCenterServicesDbSchemaMigrator : IControlCenterServicesDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}