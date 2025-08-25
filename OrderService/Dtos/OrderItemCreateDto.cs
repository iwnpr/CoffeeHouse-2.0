namespace OrderService.Dtos;

public class OrderItemCreateDto
{
    public Guid MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
