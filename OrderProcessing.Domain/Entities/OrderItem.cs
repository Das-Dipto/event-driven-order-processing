using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Domain.Entities;

public sealed class OrderItem
{
    public Guid ProductId { get; }
    public int Quantity { get; }
    public Money UnitPrice { get; }

    public OrderItem(Guid productId, int quantity, Money unitPrice)
    {
        if (productId == Guid.Empty)
            throw new ArgumentException("ProductId cannot be empty.");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    }
}
