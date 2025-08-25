namespace OrderService.Dtos;

public class OrderItemReadDto
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
