namespace WebApiDapper.Models;

public class Location
{
    public int Id { get; set; }   
    public string? City { get; set; }   
    public string? Address { get; set; }
    public string LocationType { get; set; }
}