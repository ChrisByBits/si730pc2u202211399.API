using ecomove_web_service.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u202211399.API.Sale.Domain.Aggregates;

namespace si730pc2u202211399.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<PurchaseOrder>().HasKey(po => po.Id);
        builder.Entity<PurchaseOrder>().Property(po => po.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PurchaseOrder>().Property(po => po.Customer).IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.FabricId).IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.City).IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.ResumeUrl).IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.Quantity).IsRequired();


        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}