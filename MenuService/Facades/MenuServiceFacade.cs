using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MenuService.Dtos;
using MenuService.Exceptions;
using MenuService.Interfaces;
using MenuService.Models;

namespace MenuService.Facades
{
    public class MenuServiceFacade : IMenuServiceFacade
    {
        private readonly IMenuRepository _repo;

        private readonly IMapper _mapper;

        public MenuServiceFacade(IMenuRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public async Task Update(Guid id, MenuItemUpdateDto menuItemUpdateDto)
        {
            var existing = await _repo.GetByIdAsync(id);

            if (existing is null)
                throw new MenuItemNotFoundException(id);

            _mapper.Map(menuItemUpdateDto, existing);

            await _repo.UpdateAsync(existing);
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