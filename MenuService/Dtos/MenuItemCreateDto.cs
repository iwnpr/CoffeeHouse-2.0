using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuService.Enums;

namespace MenuService.Dtos
{
    public class MenuItemCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public Category Category { get; set; }
        public int Portion { get; set; }    
    }
}