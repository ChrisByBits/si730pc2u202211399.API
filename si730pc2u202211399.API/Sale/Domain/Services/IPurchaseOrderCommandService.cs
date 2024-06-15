using si730pc2u202211399.API.Sale.Domain.Aggregates;
using si730pc2u202211399.API.Sale.Domain.Commands;

namespace si730pc2u202211399.API.Sale.Domain.Services;

public interface IPurchaseOrderCommandService
{
    public Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command);
}