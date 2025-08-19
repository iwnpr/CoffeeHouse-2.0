using System;

namespace MenuService.Exceptions
{
    public class MenuItemNotFoundException : Exception
    {
        public MenuItemNotFoundException(Guid id)
            : base($"Menu item with id '{id}' was not found.")
        {
        }
    }
}
