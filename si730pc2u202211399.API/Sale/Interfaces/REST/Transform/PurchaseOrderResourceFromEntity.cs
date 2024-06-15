using si730pc2u202211399.API.Sale.Domain.Aggregates;
using si730pc2u202211399.API.Sale.Interfaces.REST.Resources;

namespace si730pc2u202211399.API.Sale.Interfaces.REST.Transform;

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