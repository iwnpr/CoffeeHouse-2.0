using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Data;
using MenuService.Interfaces;
using MenuService.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MenuItem item)
        {
            await _context.MenuItems.AddAsync(item);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem item)
        {
            _context.MenuItems.Update(item);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item != null)
            {
                _context.MenuItems.Remove(item);
                await SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(Guid id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}