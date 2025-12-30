namespace OrderProcessing.Domain.Enums;

public enum OrderStatus
{
    Created,
    PaymentInProgress,
    PaymentFailed,
    PaymentSucceeded,
    InventoryInProgress,
    InventoryFailed,
    Completed
}