using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Exceptions;
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

        public async Task AddItem(MenuItem item)
        {
            await _repo.AddAsync(item);
        }

        public async Task<IEnumerable<MenuItem>> GetAllItems()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<MenuItem> GetById(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
            {
                throw new MenuItemNotFoundException(id);
            }

            return item;
        }

        public async Task Update(MenuItem item)
        {
            var existing = await _repo.GetByIdAsync(item.Id);
            if (existing == null)
            {
                throw new MenuItemNotFoundException(item.Id);
            }

            await _repo.UpdateAsync(item);
        }

        public async Task Delete(Guid id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                throw new MenuItemNotFoundException(id);
            }

            await _repo.DeleteAsync(id);
        }
    }
}