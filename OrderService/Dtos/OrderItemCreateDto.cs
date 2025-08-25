namespace OrderService.Dtos;

public class OrderItemCreateDto
{
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
