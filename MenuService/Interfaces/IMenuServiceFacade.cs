using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Dtos;
using MenuService.Models;

namespace MenuService.Interfaces
{
    public interface IMenuServiceFacade
    {
        Task AddItem(MenuItem item);
        Task<IEnumerable<MenuItem>> GetAllItems();
        Task<MenuItem> GetById(Guid id);
        Task Update(Guid id, MenuItemUpdateDto menuItemUpdateDto);
        Task Delete(Guid id);
    }
}