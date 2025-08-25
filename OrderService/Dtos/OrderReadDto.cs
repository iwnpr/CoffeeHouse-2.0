namespace OrderService.Dtos;

public class OrderReadDto
{
    public int Id { get; set; }
    public List<OrderItemReadDto> OrderItems { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
}
