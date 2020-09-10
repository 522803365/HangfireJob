using System.IO;
using ControlCenterServices.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ControlCenterServices.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ControlCenterServicesMigrationsDbContextFactory : IDesignTimeDbContextFactory<ControlCenterServicesMigrationsDbContext>
    {
        public ControlCenterServicesMigrationsDbContext CreateDbContext(string[] args)
        {
            ControlCenterServicesEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ControlCenterServicesMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ControlCenterServicesMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ControlCenterServices.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
