
using si730pc2u202211399.API.Sale.Domain.Model.Commands;
using si730pc2u202211399.API.Sale.Domain.Model.ValueObjects;

namespace si730pc2u202211399.API.Sale.Domain.Model.Aggregates;

/**
 * PurchaseOrder aggregate root
 *
 * <summary>
 *      Represents the PurchaseOrder aggregate root.
 * </summary>
 * <remarks>
 *  <author>U202211399 Christopher Lecca</author>
 *  <version>1.0</version>
 * </remarks>
 */

public partial class PurchaseOrder
{
    public PurchaseOrder()
    {
        Customer = String.Empty;
        FabricId = 0;
        City = String.Empty;
        ResumeUrl = String.Empty;
        Quantity = 0;
    }
    public PurchaseOrder(string customer, EFabric fabricId, string city, string resumeUrl, int quantity)
    {
        Customer = customer;
        FabricId = fabricId;
        City = city;
        ResumeUrl = resumeUrl;
        Quantity = quantity;
    }

    public PurchaseOrder(CreatePurchaseOrderCommand command)
    {
        Customer = command.Customer;
        FabricId = command.FabricId;
        City = command.City;
        ResumeUrl = command.ResumeUrl;
        Quantity = command.Quantity;
    }
    
    public int Id { get; private set; }
    public string Customer { get; private set; }
    public EFabric FabricId { get; private set; }
    public string City { get; private set; }
    public string ResumeUrl { get; private set; }
    public int Quantity { get; private set; }
}