using si730pc2u202211399.API.Sale.Domain.Model.Aggregates;
using si730pc2u202211399.API.Sale.Domain.Model.ValueObjects;
using si730pc2u202211399.API.Shared.Domain.Repositories;

namespace si730pc2u202211399.API.Sale.Domain.Repositories;

/**
 * PurchaseOrder repository
 * <summary>
 *   Represents the PurchaseOrder repository interface.
 * </summary>
 * <remarks>
 *   <author>U202211399 Christopher Lecca</author>
 *   <version>1.0.0</version>
 * </remarks>
 */

public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
{
   public Task<PurchaseOrder?> FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId);
}