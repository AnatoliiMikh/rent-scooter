﻿//namespace RentScooter.Context.Entities;
//public class Scooter : BaseEntity
//{
//    //public int? RentalId { get; set; }
//    //public virtual Rental Rental { get; set; }
//    public string Name { get; set; } //У каждого скутера есть название и только одно
//    public bool IsInUse { get; set; }
//    public decimal PricePerMinute { get; set; }

//    //public int? RentalId { get; set; }


//    // public virtual ScooterDetail Detail { get; set; } //Detail так как у одного скутера одни и только одни данные, связь 1:1

//    public virtual ICollection<Rental> Rentals { get; set; } //Rentals, так как у каждого скутера есть много разных аренд
    
//    //public string Name { get; set; }
//    //public bool IsInUse { get; set; }
//    //public decimal PricePerMinute { get; set; }

//    //public List<Rental> Rentals { get; set; }
//}

namespace RentScooter.Context.Entities;

public class Scooter : BaseEntity
{
    public int? BrandId { get; set; }
    public virtual Brand Brand { get; set; } //Author to Brand

    public string Title { get; set; } //Title to Name
    public string Description { get; set; }

    public decimal PricePerMinute { get; set; }
    public bool IsInUse { get; set; }

    public virtual ICollection<Rent> Rents { get; set; } //Categories to Rents
}
