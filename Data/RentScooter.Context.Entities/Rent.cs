namespace RentScooter.Context.Entities;

public class Rent : BaseEntity
{
    public string Title { get; set; }
    public virtual ICollection<Scooter> Scooters { get; set; }
}
