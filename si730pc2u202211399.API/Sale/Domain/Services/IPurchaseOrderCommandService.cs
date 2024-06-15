using si730pc2u202211399.API.Sale.Domain.Model.Aggregates;
using si730pc2u202211399.API.Sale.Domain.Model.Commands;

namespace si730pc2u202211399.API.Sale.Domain.Services;

/**
 * PurchaseOrder command service
 * <summary>
 *    Represents the PurchaseOrder command service interface.
 * </summary>
 * <remarks>
 *  <author>U202211399 Christopher Lecca</author>
 *  <version>1.0.0</version>
 * </remarks>
 */

public interface IPurchaseOrderCommandService
{
    public Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command);
}