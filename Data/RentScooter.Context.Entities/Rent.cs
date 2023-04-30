namespace RentScooter.Context.Entities;

public class Rent : BaseEntity
{
    public string Title { get; set; }
    public decimal TotalRevenue { get; set; }
    public DateTime RentTime { get; set; }
    public DateTime ReturnTime { get; set; }
    public virtual ICollection<Scooter> Scooters { get; set; }
}
