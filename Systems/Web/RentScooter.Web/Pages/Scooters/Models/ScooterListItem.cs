namespace RentScooter.Web;

public class ScooterListItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
}

