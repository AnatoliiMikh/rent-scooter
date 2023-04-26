//namespace RentScooter.Context.Entities;

//using System.ComponentModel.DataAnnotations;

//public class ScooterDetail //: BaseEntity
//{
//    [Key]
//    public int Id { get; set; }
//    public virtual Scooter Scooter { get; set; } //Навигационное свойство на сущность Скутер - у каждой детали один скутер, связь 1:1

//    public bool IsInUse { get; set; } //Булевое поле "используется или нет"
//    public decimal PricePerMinute { get; set; } //Значение цены самоката за минуту

//}