using System;
using System.Threading.Tasks;
using ControlCenterServices.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace ControlCenterServices.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class EntityFrameworkCoreControlCenterServicesDbSchemaMigrator
        : IControlCenterServicesDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreControlCenterServicesDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ControlCenterServicesMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ControlCenterServicesMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}