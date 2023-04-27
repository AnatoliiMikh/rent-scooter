namespace RentScooter.Services.Scooters;

public interface IScooterService
{
    Task<IEnumerable<ScooterModel>> GetScooters();
}