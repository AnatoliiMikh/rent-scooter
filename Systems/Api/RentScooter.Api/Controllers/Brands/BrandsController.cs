namespace RentScooter.API.Controllers.Brands;

using AutoMapper;
using RentScooter.API.Controllers.Brands.Models;
using RentScooter.Common.Security;
using RentScooter.Services.Brands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/brands")]
[ApiController]
[ApiVersion("1.0")]
public class BrandsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<BrandsController> logger;
    private readonly IBrandService brandService;

    public BrandsController(IMapper mapper, ILogger<BrandsController> logger, IBrandService brandService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.brandService = brandService;
    }

    /// <summary>
    /// Get brands
    /// </summary>
    [HttpGet("")]
    [Authorize(AppScopes.ScootersRead)]
    public async Task<IEnumerable<BrandResponse>> GetBrands()
    {
        var scooters = await brandService.GetBrands();
        var response = mapper.Map<IEnumerable<BrandResponse>>(scooters);

        return response;
    }
}
