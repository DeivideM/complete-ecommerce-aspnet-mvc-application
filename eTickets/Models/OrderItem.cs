using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models;

public class OrderItem
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    // Foreign keys
    public int MovieId { get; set; }
    [ForeignKey("MovieId")]
    public virtual Movie Movie { get; set; }
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    public Order Order { get; set; }
}