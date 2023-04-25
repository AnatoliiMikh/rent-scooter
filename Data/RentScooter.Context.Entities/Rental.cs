namespace RentScooter.Context.Entities;
public class Rental : BaseEntity
{
    public int? ScooterId { get; set; }
    public virtual Scooter Scooter { get; set; }

    public virtual ICollection<ScooterDetail> ScooterDetails { get; set; }

    //public int Id { get; set; }
    //public int UserId { get; set; }
    //public int ScooterId { get; set; }
    //public DateTime StartDate { get; set; }
    //public DateTime EndDate { get; set; }
    //public decimal Cost { get; set; }

    //public User User { get; set; }
    //public Scooter Scooter { get; set; }
}