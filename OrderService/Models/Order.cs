namespace OrderService.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
}
