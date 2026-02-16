using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed record OrderCompletedEvent(OrderId OrderId);
