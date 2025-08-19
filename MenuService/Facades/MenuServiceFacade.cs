using MenuService.Interfaces;
using MenuService.Models;

namespace MenuService.Facades
{
    public class MenuServiceFacade : IMenuServiceFacade
    {
        private readonly IMenuRepository _repo;

        public MenuServiceFacade(IMenuRepository repo)
        {
            _repo = repo;
        }

        public void AddItem(MenuItem item)
        {
            try
            {
                _repo.Add(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MenuItem> GetAllItems()
        {
            try
            {
                var allItems = _repo.GetAll();
                return allItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MenuItem GetById(Guid id)
        {
            try
            {
                var item = _repo.GetById(id);

                if (item == null)
                {
                    throw new Exception("Item not found.");
                }
                
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(MenuItem item)
        {
            try
            {
                var existing = _repo.GetById(item.Id) ?? throw new Exception("Item not found.");
                _repo.Update(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var existing = _repo.GetById(id) ?? throw new Exception("Item not found.");
                _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}