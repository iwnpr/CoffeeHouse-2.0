
using AutoMapper;
using MenuService.Dtos;
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
        public ActionResult<MenuItemReadDto> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemCreateDto);
            _facade.AddItem(menuItem);
            

            var menuItemReadDto = _mapper.Map<MenuItemReadDto>(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = menuItemReadDto.Id }, menuItemReadDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuItemReadDto>> GetMenuItems()
        {
            var menuItems = _facade.GetAllItems();
            return Ok(_mapper.Map<IEnumerable<MenuItemReadDto>>(menuItems));
        }

        [HttpGet("{id}")]
        public ActionResult<MenuItemReadDto> GetMenuItemById(Guid id)
        {
            var menuItem = _facade.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<MenuItemReadDto>(menuItem));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(MenuItemReadDto menuItemUpdateDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemUpdateDto);
            return Ok(_mapper.Map<MenuItemReadDto>(menuItem));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(Guid id)
        {
            _facade.Delete(id);
            return Ok();
        }



    }
}