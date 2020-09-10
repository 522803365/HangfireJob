using System.Threading.Tasks;

namespace ControlCenterServices.Domain.Data
{
    public interface IControlCenterServicesDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
