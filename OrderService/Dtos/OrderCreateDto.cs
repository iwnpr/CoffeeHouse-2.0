namespace OrderService.Dtos;

public class OrderCreateDto
{
    public List<OrderItemCreateDto> OrderItems { get; set; } = new();
}
