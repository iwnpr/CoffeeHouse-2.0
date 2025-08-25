using OrderService.Models;

namespace OrderService.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task UpdateAsync(Order order);
    Task<bool> SaveChangesAsync();
}
