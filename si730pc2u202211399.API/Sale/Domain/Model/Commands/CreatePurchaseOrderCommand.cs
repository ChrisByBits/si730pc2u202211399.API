using si730pc2u202211399.API.Sale.Domain.Model.ValueObjects;

namespace si730pc2u202211399.API.Sale.Domain.Model.Commands;

/**
 * Command to create a purchase order
 * <summary>
 *     Represents the command to create a purchase order.
 * </summary>
 * <remarks>
 *   <author>U202211399 Christopher Lecca</author>
 *   <version>1.0.0</version>
 * </remarks>
 * <param name="Customer">The customer name</param>
 * <param name="FabricId">The fabric id</param>
 * <param name="City">The city</param>
 * <param name="ResumeUrl">The resume url</param>
 * <param name="Quantity">The quantity</param>
 * 
 */
public record CreatePurchaseOrderCommand(string Customer, EFabric FabricId, string City, string ResumeUrl, int Quantity);