using Microsoft.EntityFrameworkCore;
using si730pc2u202211399.API.Sale.Domain.Aggregates;
using si730pc2u202211399.API.Sale.Domain.Repositories;
using si730pc2u202211399.API.Sale.Domain.ValueObjects;
using si730pc2u202211399.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u202211399.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730pc2u202211399.API.Sale.Infrastructure.Persistence.EFC.Repositories;

public class PurchaseOrderRepository(AppDbContext context)
    : BaseRepository<PurchaseOrder>(context), IPurchaseOrderRepository
{
    public async Task<PurchaseOrder?> FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId)
    {
        return await Context.Set<PurchaseOrder>().FirstOrDefaultAsync(po => po.Customer == customer && po.FabricId == fabricId);
    }
}
