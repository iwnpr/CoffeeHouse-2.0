using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Models;

namespace MenuService.Interfaces
{
    public interface IMenuServiceFacade
    {
        Task AddItem(MenuItem item);
        Task<IEnumerable<MenuItem>> GetAllItems();
        Task<MenuItem> GetById(Guid id);
        Task Update(MenuItem item);
        Task Delete(Guid id);
    }
}