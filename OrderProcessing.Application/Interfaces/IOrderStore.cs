using OrderProcessing.Domain.Aggregates;
using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Interfaces;

public interface IOrderStore
{
    void Save(Order order);
    Order Get(OrderId orderId);
}
