namespace OrderService.Dtos
{
    public class OrderItemReadDto
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}