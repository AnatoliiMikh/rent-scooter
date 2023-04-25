namespace RentScooter.Context.Entities;

public class Report 
{
    public int Id { get; set; }
    public int PeriodId { get; set; }
    public decimal Income { get; set; }

    public Period Period { get; set; }
}
