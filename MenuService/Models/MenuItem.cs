using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuService.Enums;

namespace MenuService.Models
{
    public class MenuItem
    {
        public MenuItem(string name, string description, long price, Category category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            IsActive = true;
        }

        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string? Description { get;  set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
        public int Portion { get; set; }

    }
}