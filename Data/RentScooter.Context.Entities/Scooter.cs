namespace RentScooter.Context.Entities;
public class Scooter : BaseEntity
{
    public string Name { get; set; }
    public virtual ScooterDetail Detail { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; }

    //public string Name { get; set; }
    //public bool IsInUse { get; set; }
    //public decimal PricePerMinute { get; set; }

    //public List<Rental> Rentals { get; set; }
}