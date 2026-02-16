using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Commands;

public sealed record ReserveInventoryCommand(OrderId OrderId);
