namespace WebApiDapper.Models;

public class Purchase
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }
}