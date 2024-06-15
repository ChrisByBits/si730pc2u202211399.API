using si730pc2u202211399.API.Sale.Domain.Model.Commands;
using si730pc2u202211399.API.Sale.Interfaces.REST.Resources;

namespace si730pc2u202211399.API.Sale.Interfaces.REST.Transform;

public static class CreatePurchaseOrderCommandFromResource
{
    public static CreatePurchaseOrderCommand ToCommandFromResource(CreatePurchaseOrderResource resource)
    {
        return new CreatePurchaseOrderCommand(
            resource.Customer,
            resource.FabricId,
            resource.City,
            resource.ResumeUrl,
            resource.Quantity
        );
    }
}