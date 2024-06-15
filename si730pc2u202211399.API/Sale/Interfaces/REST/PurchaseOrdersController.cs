using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730pc2u202211399.API.Sale.Domain.Services;
using si730pc2u202211399.API.Sale.Interfaces.REST.Resources;
using si730pc2u202211399.API.Sale.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace si730pc2u202211399.API.Sale.Interfaces.REST;

/**
 * Purchase Orders Controller
 * <summary>
 *    This class is responsible for handling the purchase orders.
 * </summary>
 * <remarks>
 *   This class contains the methods to create, read, update and delete purchase orders.
 *   <author> U202211399 Christopher Lecca </author>
 *   <version> 1.0.0 </version>
 * </remarks>
 */
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PurchaseOrdersController
(IPurchaseOrderCommandService purchaseOrderCommandService) : ControllerBase
{
    /**
     * Create Purchase Order
     * <summary>
     *    This method is responsible for handling the request to create a new purchase order.
     * </summary>
     * <param name="createPurchaseOrderResource">The resource containing the information to create a new purchase order.</param>
     * <returns>The newly created purchase order resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a purchase order",
        Description = "Creates a purchase order with a given customer, fabric, city, resume url and quantity",
        OperationId = "CreatePurchaseOrder")]
    [SwaggerResponse(201, "The purchase order was created", typeof(PurchaseOrderResource))]
    public async Task<IActionResult> CreatePurchaseOrder([FromBody] CreatePurchaseOrderResource createPurchaseOrderResource)
    {
        var createPurchaseOrderCommand =
            CreatePurchaseOrderCommandFromResource.ToCommandFromResource(createPurchaseOrderResource);
        var purchaseOrder = await purchaseOrderCommandService.Handle(createPurchaseOrderCommand);
        if (purchaseOrder is null) return BadRequest();
        var resource = PurchaseOrderResourceFromEntity.ToResourceFromEntity(purchaseOrder);
        return Created("api/purchaseorders/" + resource.Id, resource);
    }
    
    
}