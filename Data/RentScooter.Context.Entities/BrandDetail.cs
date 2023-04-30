namespace RentScooter.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class BrandDetail
{
    [Key]
    public int Id { get; set; }
    public virtual Brand Brand { get; set; }

    public string StockTicket { get; set; } 
    public string Country { get; set; }
}
