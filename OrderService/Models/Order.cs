namespace OrderService.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
}