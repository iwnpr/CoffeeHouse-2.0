using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuService.Models;

namespace MenuService.Interfaces
{
    public interface IMenuRepository
    {
        void Add(MenuItem item);
        void Update(MenuItem item);
        void Delete(Guid id);
        IEnumerable<MenuItem> GetAll();
        MenuItem GetById(Guid id);
        bool SaveChanges();
    }
}