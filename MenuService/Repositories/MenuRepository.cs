using MenuService.Data;
using MenuService.Interfaces;
using MenuService.Models;

namespace MenuService.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(MenuItem item)
        {
            _context.MenuItems.Add(item);
            SaveChanges();
        }

        public void Update(MenuItem item)
        {
            _context.MenuItems.Update(item);
            SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item = _context.MenuItems.Find(id);
            _context.MenuItems.Remove(item);
            SaveChanges();
        }

        public IEnumerable<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }

        public MenuItem GetById(Guid id)
        {
            return _context.MenuItems.Find(id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}