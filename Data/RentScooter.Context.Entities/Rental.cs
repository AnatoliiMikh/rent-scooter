using System.ComponentModel.DataAnnotations;

namespace RentScooter.Context.Entities;
public class Rental : BaseEntity
{
    //[Key]
    //public int Id { get; set; }
    public int? ScooterId { get; set; } //У каждой аренды есть задействованый самокат,
                                        //и только один притом у каждого самоката может быть много аренд а может и не быть - связь 1:n
                                        //ВАЖНО: если мы удаляем скутер, то отчет все равно остается (как если мы удалим автора, то книга все равно останется)
                                        //поэтому "?" и .OnDelete(DeleteBehavior.Restrict);
    public virtual Scooter Scooter { get; set; } //Навигационное свойство на сущность скутеры 
    public DateTime StartDate { get; set; } //Дата начала аренды
    public DateTime EndDate { get; set; } //Дата конца аренды

    public virtual Report Report { get; set; }

    //public virtual ICollection<Report> Report { get; set; } //У аренды может быть только один отчет, а может и не быть,
                                                            //У каждого отчета обязательно должен быть запись аренды,
                                                            //связь 1:1

    //public int Id { get; set; }
    //public int UserId { get; set; }
    //public int ScooterId { get; set; }
    //public DateTime StartDate { get; set; }
    //public DateTime EndDate { get; set; }
    //public decimal Cost { get; set; }

    //public User User { get; set; }
    //public Scooter Scooter { get; set; }
}