namespace RentScooter.Services.Rents;

public interface IRentService
{
    Task<IEnumerable<RentModel>> GetRents();
}
