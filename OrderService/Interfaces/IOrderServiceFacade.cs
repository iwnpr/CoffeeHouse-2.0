using OrderService.Models;

namespace OrderService.Interfaces;

public interface IOrderServiceFacade
{
    Task<Order> CreateOrder(Order order);
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> GetOrderById(int id);
}
