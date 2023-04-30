//namespace RentScooter.Api.Controllers.Rents;
namespace RentScooter.Api.Controllers;


using AutoMapper;
using RentScooter.API.Controllers.Models;

//using RentScooter.API.Controllers.Rents.Models;
//using RentScooter.API.Controllers.Rents.Models;
using RentScooter.Common.Security;
using RentScooter.Services.Rents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using RentScooter.API.Controllers.Brands.Models;

//using RentScooter.Services.Brands;

//using RentScooter.API.Controllers.Brands;
//using RentScooter.Services.Brands;

[Route("api/v{version:apiVersion}/rents")]
[ApiController]
[ApiVersion("1.0")]
public class RentsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<RentsController> logger;
    private readonly IRentService rentService;

    public RentsController(IMapper mapper, ILogger<RentsController> logger, IRentService rentService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.rentService = rentService;
    }

    /// <summary>
    /// Get rents
    /// </summary>
    [HttpGet("")]
    [Authorize(AppScopes.ScootersRead)]
    public async Task<IEnumerable<RentResponse>> GetRents()
    {
        var scooters = await rentService.GetRents();
        var response = mapper.Map<IEnumerable<RentResponse>>(scooters);

        return response;
    }
}
