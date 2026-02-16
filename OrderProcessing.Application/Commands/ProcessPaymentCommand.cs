using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Commands;

public sealed record ProcessPaymentCommand(OrderId OrderId);
