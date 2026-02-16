using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed record PaymentFailedEvent(OrderId OrderId);
