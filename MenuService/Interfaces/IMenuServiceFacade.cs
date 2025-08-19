using MenuService.Models;

namespace MenuService.Interfaces
{
    public interface IMenuServiceFacade
    {
        void AddItem(MenuItem item);
        IEnumerable<MenuItem> GetAllItems();
        MenuItem GetById(Guid id);
        void Update(MenuItem item);
        void Delete(Guid id);
    }
}