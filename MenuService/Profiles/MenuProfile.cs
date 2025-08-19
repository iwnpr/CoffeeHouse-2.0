using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MenuService.Dtos;
using MenuService.Models;

namespace MenuService.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            // Source -> Target
            CreateMap<MenuItem, MenuItemReadDto>();
            CreateMap<MenuItemCreateDto, MenuItem>();
        }
    }
}