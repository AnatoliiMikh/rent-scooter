namespace RentScooter.Web;

public class ScooterListItem
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
