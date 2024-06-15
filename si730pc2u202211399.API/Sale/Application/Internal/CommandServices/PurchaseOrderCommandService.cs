using si730pc2u202211399.API.Sale.Domain.Model.Aggregates;
using si730pc2u202211399.API.Sale.Domain.Model.Commands;
using si730pc2u202211399.API.Sale.Domain.Model.Exceptions;
using si730pc2u202211399.API.Sale.Domain.Repositories;
using si730pc2u202211399.API.Sale.Domain.Services;
using si730pc2u202211399.API.Sale.Domain.Model.ValueObjects;
using si730pc2u202211399.API.Shared.Domain.Repositories;

namespace si730pc2u202211399.API.Sale.Application.Internal.CommandServices;

/**
 * Service responsible for handling purchase order commands.
 * <summary>
 *   This service is responsible for handling purchase order commands.
 * </summary>
 * <remarks>
 *    <author> U202211399 Christopher Lecca </author>
 *    <version> 1.0.0 </version>
 * </remarks>
 * 
 */
public class PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork) :
    IPurchaseOrderCommandService
{
    public async Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command)
    {
        var existingPurchaseOrder = await purchaseOrderRepository.FindByCustomerAndFabricIdAsync(command.Customer, command.FabricId);
        if (existingPurchaseOrder != null)
        {
            throw new PurchaseOrderWithTheCurrentCustomerAndFabricAlreadyExistsException("Purchase order already exists for the customer and fabric.");
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