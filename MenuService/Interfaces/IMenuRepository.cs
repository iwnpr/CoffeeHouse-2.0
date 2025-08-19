using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuService.Models;

namespace MenuService.Interfaces
{
    public interface IMenuRepository
    {
        Task AddAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(Guid id);
        Task<bool> SaveChangesAsync();
    }
}