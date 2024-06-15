namespace si730pc2u202211399.API.Sale.Domain.Model.Exceptions;

/**
 * Exception to be thrown when a purchase order with the current customer and fabric already exists
 * <summary>
 *    Represents the exception to be thrown when a purchase order with the current customer and fabric already exists.
 * </summary>
 * <remarks>
 *   <author>U202211399 Christopher Lecca</author>
 *   <version>1.0.0</version>
 * </remarks>
 */
public class PurchaseOrderWithTheCurrentCustomerAndFabricAlreadyExistsException : Exception
{
    public PurchaseOrderWithTheCurrentCustomerAndFabricAlreadyExistsException(string message) : base(message)
    {
    }
}