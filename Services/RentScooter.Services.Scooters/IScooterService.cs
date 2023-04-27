namespace RentScooter.Services.Scooters;

public interface IScooterService
{
    Task<IEnumerable<ScooterModel>> GetScooters(int offset = 0, int limit = 10);
    Task<ScooterModel> GetScooter(int scooterId);
    Task<ScooterModel> GetScooter(AddScooterModel model);
    Task UpdateScooter(int id, UpdateScooterModel model);
    Task DeleteScooter(int scooterId);
}