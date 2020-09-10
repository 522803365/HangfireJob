using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ControlCenterServices.EntityFrameworkCore.EntityFrameworkCore
{
    public static class ControlCenterServicesDbContextModelCreatingExtensions
    {
        public static void ConfigureControlCenterServices(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ControlCenterServicesConsts.DbTablePrefix + "YourEntities", ControlCenterServicesConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}