using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed record PaymentRequestedEvent(OrderId OrderId);
