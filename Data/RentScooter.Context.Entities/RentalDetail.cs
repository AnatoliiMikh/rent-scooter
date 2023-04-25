namespace RentScooter.Context.Entities;

public class RentalDetail : BaseEntity
{
    public string Cost { get; set; }
    public virtual ICollection<Rental> Rental { get; set; }
}
