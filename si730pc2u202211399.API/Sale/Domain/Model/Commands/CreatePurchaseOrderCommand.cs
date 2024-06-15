using si730pc2u202211399.API.Sale.Domain.ValueObjects;

namespace si730pc2u202211399.API.Sale.Domain.Commands;

public record CreatePurchaseOrderCommand(string Customer, EFabric FabricId, string City, string ResumeUrl, int Quantity);