using MenuService.Models;
using MenuService.Enums;
using MenuService.Data;

namespace MenuService.DataisProd
{
    public static class PrepDb
    {
          public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.MenuItems.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                
                context.MenuItems.AddRange(
                    
                    new MenuItem("Espresso", "Strong and bold coffee", 150, Category.Coffee),
                    new MenuItem("Latte", "Creamy coffee with milk", 200, Category.Coffee),
                    new MenuItem("Cappuccino", "Coffee with steamed milk and foam", 220, Category.Coffee),
                    new MenuItem("Americano", "Espresso with hot water", 180, Category.Coffee),
                    new MenuItem("Mocha", "Chocolate-flavored coffee", 250, Category.Coffee),
                    new MenuItem("Black Tea", "Strong brewed black tea", 100, Category.Tea),
                    new MenuItem("Green Tea", "Light and refreshing green tea", 120, Category.Tea),
                    new MenuItem("Herbal Tea", "Caffeine-free herbal infusion", 110, Category.Tea),
                    new MenuItem("Chai Latte", "Spiced tea with milk", 180, Category.Tea),
                    new MenuItem("Iced Coffee", "Chilled coffee beverage", 200, Category.Coffee),
                    new MenuItem("Iced Tea", "Refreshing iced tea", 150, Category.Tea)
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}