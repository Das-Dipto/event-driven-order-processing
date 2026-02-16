using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed record InventoryReservationFailedEvent(OrderId OrderId);
