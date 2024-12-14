namespace WebApiDapper.Models;

public class Ticket
{
    public int? Id { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public double? Price { get; set; }
    public DateTime EventDateTime { get; set; }
}