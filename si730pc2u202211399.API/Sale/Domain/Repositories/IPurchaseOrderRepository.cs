using si730pc2u202211399.API.Sale.Domain.Aggregates;
using si730pc2u202211399.API.Sale.Domain.ValueObjects;
using si730pc2u202211399.API.Shared.Domain.Repositories;

namespace si730pc2u202211399.API.Sale.Domain.Repositories;

public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
{
   public Task<PurchaseOrder?> FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId);
}