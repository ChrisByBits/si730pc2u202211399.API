using si730pc2u202211399.API.Sale.Domain.Model.Aggregates;
using si730pc2u202211399.API.Sale.Interfaces.REST.Resources;

namespace si730pc2u202211399.API.Sale.Interfaces.REST.Transform;

/**
 * PurchaseOrder resource from entity
 * <summary>
 *   Represents the PurchaseOrder resource from entity.
 * </summary>
 * <remarks>
 *  <author>U202211399 Christopher Lecca</author>
 *  <version>1.0.0</version>
 * </remarks>
 * <param name="purchaseOrder">The purchase order</param>
 */
public static class PurchaseOrderResourceFromEntity
{
    public static PurchaseOrderResource ToResourceFromEntity(PurchaseOrder purchaseOrder)
    {
        return new PurchaseOrderResource(
            purchaseOrder.Id,
            purchaseOrder.Customer,
            purchaseOrder.FabricId,
            purchaseOrder.City,
            purchaseOrder.ResumeUrl,
            purchaseOrder.Quantity
        );
    }
}