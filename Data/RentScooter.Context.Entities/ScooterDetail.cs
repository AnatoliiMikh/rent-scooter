namespace RentScooter.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class ScooterDetail
{
    [Key]
    public int Id { get; set; }
    public virtual Scooter Scooter { get; set; }

    public bool IsInUse { get; set; }
    public decimal PricePerMinute { get; set; }

}