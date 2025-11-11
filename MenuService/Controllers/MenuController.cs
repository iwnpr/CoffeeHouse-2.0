
using AutoMapper;
using MenuService.Dtos;
using MenuService.Exceptions;
using MenuService.Interfaces;
using MenuService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MenuService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServiceFacade _facade;
        private readonly IMapper _mapper;

        public MenuController(IMenuServiceFacade facade, IMapper mapper)
        {
            _facade = facade;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemReadDto>> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemCreateDto);
            await _facade.AddItem(menuItem);

            var menuItemReadDto = _mapper.Map<MenuItemReadDto>(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = menuItemReadDto.Id }, menuItemReadDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemReadDto>>> GetMenuItems()
        {
            var menuItems = await _facade.GetAllItems();
            return Ok(_mapper.Map<IEnumerable<MenuItemReadDto>>(menuItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemReadDto>> GetMenuItemById(Guid id)
        {
            try
            {
                var menuItem = await _facade.GetById(id);
                return Ok(_mapper.Map<MenuItemReadDto>(menuItem));
            }
            catch (MenuItemNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuItem(Guid id, MenuItemUpdateDto menuItemUpdateDto)
        {
            try
            {
                await _facade.Update(id, menuItemUpdateDto);
                return Ok();
            }
            catch (MenuItemNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(Guid id)
        {
            try
            {
                await _facade.Delete(id);
                return Ok();
            }
            catch (MenuItemNotFoundException)
            {
                return NotFound();
            }
        }



    }
}