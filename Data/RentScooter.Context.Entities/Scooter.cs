namespace RentScooter.Context.Entities;

public class Scooter : BaseEntity
{
    public int? BrandId { get; set; }
    public virtual Brand Brand { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public decimal PricePerMinute { get; set; }
    public bool IsInUse { get; set; }

    public virtual ICollection<Rent> Rents { get; set; }
}
