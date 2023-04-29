namespace RentScooter.Context.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public virtual BrandDetail Detail { get; set; }

    public virtual ICollection<Scooter> Scooters { get; set; }
}
