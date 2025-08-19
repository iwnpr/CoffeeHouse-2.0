using MenuService.Enums;

namespace MenuService.Dtos
{
    public class MenuItemReadDto
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
        public int Portion { get; set; }
    }
}