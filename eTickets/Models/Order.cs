namespace eTickets.Models;

public class Order
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserId { get; set; }
    //public DateTime OrderPlaced { get; set; }
    //public decimal TotalAmount { get; set; }
    // Navigation property
    public List<OrderItem> OrderItems { get; set; }
}
