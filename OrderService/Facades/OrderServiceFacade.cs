using OrderService.Exceptions;
using OrderService.Interfaces;
using OrderService.Models;

namespace OrderService.Facades;

public class OrderServiceFacade : IOrderServiceFacade
{
    private readonly IOrderRepository _repo;

    public OrderServiceFacade(IOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        order.CreatedAt = DateTime.UtcNow;
        order.Status = "Pending";
        order.TotalPrice = order.OrderItems.Sum(i => i.Price * i.Quantity);
        await _repo.AddAsync(order);
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Order> GetOrderById(Guid id)
    {
        var order = await _repo.GetByIdAsync(id);
        if (order == null)
        {
            throw new OrderNotFoundException(id);
        }
        return order;
    }
}