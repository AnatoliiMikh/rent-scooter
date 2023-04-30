namespace RentScooter.Web;

using System.Threading.Tasks;

public interface IScooterService
{
    Task<IEnumerable<ScooterListItem>> GetScooters(int offset = 0, int limit = 10);
    Task<ScooterListItem> GetScooter(int scooterId);
    Task AddScooter(ScooterModel model);
    Task EditScooter(int scooterId, ScooterModel model);
    Task DeleteScooter(int scooterId);

    Task<IEnumerable<BrandModel>> GetBrandList();
}
