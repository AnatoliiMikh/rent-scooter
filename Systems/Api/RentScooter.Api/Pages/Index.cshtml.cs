namespace RentScooter.Api.Pages;

using RentScooter.Api.Settings;
using RentScooter.Common;
using RentScooter.Services.Settings; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

public class IndexModel : PageModel
{
    [BindProperty]
    public bool OpenApiEnabled => settings.Enabled; //Изменил на 1:47:12

    [BindProperty]
    public string Version => Assembly.GetExecutingAssembly().GetAssemblyVersion();

    [BindProperty]
    public string HelloMessage => apiSettings.HelloMessage; //Изменил на 1:47:18


    private readonly SwaggerSettings settings;
    private readonly ApiSpecialSettings apiSettings;

    public IndexModel(SwaggerSettings settings, ApiSpecialSettings apiSettings)
    {
        this.settings = settings;
        this.apiSettings = apiSettings;
    }

    public void OnGet()
    {
    }
}
