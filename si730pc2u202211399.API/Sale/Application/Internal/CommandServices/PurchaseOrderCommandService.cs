using si730pc2u202211399.API.Sale.Domain.Aggregates;
using si730pc2u202211399.API.Sale.Domain.Commands;
using si730pc2u202211399.API.Sale.Domain.Repositories;
using si730pc2u202211399.API.Sale.Domain.Services;
using si730pc2u202211399.API.Sale.Domain.ValueObjects;
using si730pc2u202211399.API.Shared.Domain.Repositories;

namespace si730pc2u202211399.API.Sale.Application.Internal.CommandServices;

public class PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork) :
    IPurchaseOrderCommandService
{
    public async Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command)
    {
        var existingPurchaseOrder = await purchaseOrderRepository.FindByCustomerAndFabricIdAsync(command.Customer, command.FabricId);
        if (existingPurchaseOrder != null)
        {
            throw new Exception("Purchase order already exists for the customer and fabric.");
        }
        if(command.FabricId > EFabric.Lyocell || command.FabricId < EFabric.Algodon)
        {
            throw new Exception("Invalid fabric id.");
        }
        
        var purchaseOrder = new PurchaseOrder(command.Customer, command.FabricId, command.City, command.ResumeUrl, command.Quantity);
        await purchaseOrderRepository.AddAsync(purchaseOrder);
        await unitOfWork.CompleteAsync();
        return purchaseOrder;
        
    }
}