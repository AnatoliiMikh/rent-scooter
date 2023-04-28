namespace RentScooter.Web;

using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ScooterService : IScooterService
{
    private readonly HttpClient _httpClient;

    public ScooterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ScooterListItem>> GetScooters(int offset = 0, int limit = 10)
    {
        string url = $"{Settings.ApiRoot}/v1/scooters?offset={offset}&limit={limit}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<ScooterListItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ScooterListItem>();

        return data;
    }

    public async Task<ScooterListItem> GetScooter(int scooterId)
    {
        string url = $"{Settings.ApiRoot}/v1/scooters/{scooterId}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<ScooterListItem>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ScooterListItem();

        return data;
    }

    public async Task AddScooter(ScooterModel model)
    {
        string url = $"{Settings.ApiRoot}/v1/scooters";

        var body = JsonSerializer.Serialize(model);
        var request = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }    
    
    public async Task EditScooter(int scooterId, ScooterModel model)
    {
        string url = $"{Settings.ApiRoot}/v1/scooters/{scooterId}";

        var body = JsonSerializer.Serialize(model);
        var request = new StringContent(body, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteScooter(int scooterId)
    {
        string url = $"{Settings.ApiRoot}/v1/scooters/{scooterId}";

        var response = await _httpClient.DeleteAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    //public async Task<IEnumerable<AuthorModel>> GetAuthorList()
    //{
    //    string url = $"{Settings.ApiRoot}/v1/authors";

    //    var response = await _httpClient.GetAsync(url);
    //    var content = await response.Content.ReadAsStringAsync();

    //    if (!response.IsSuccessStatusCode)
    //    {
    //        throw new Exception(content);
    //    }

    //    var data = JsonSerializer.Deserialize<IEnumerable<AuthorModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AuthorModel>();

    //    return data;
    //}
}
