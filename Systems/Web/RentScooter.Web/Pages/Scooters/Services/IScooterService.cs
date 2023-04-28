namespace RentScooter.Web;

using System.Threading.Tasks;

public interface IScooterService
{
    Task<IEnumerable<ScooterListItem>> GetScooters(int offset = 0, int limit = 10);
    Task<ScooterListItem> GetScooter(int scooterId);
    Task AddScooter(ScooterModel model);
    Task EditScooter(int bookId, ScooterModel model);
    Task DeleteScooter(int bookId);

    //Task<IEnumerable<AuthorModel>> GetAuthorList();
}
