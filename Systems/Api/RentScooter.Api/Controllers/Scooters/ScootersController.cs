﻿namespace RentScooter.API.Controllers;

using AutoMapper;
using RentScooter.API.Controllers.Models;
using RentScooter.Common.Responses;
using RentScooter.Common.Security;
using RentScooter.Services.Scooters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Scooters controller
/// </summary>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="403">Forbidden</response>
/// <response code="404">Not Found</response>
[ProducesResponseType(typeof(ErrorResponse), 400)]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/scooters")]
[Authorize]
[ApiController]
[ApiVersion("1.0")]
public class ScootersController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<ScootersController> logger;
    private readonly IScooterService scooterService;

    public ScootersController(IMapper mapper, ILogger<ScootersController> logger, IScooterService scooterService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.scooterService = scooterService;
    }


    /// <summary>
    /// Get scooters
    /// </summary>
    /// <param name="offset">Offset to the first element</param>
    /// <param name="limit">Count elements on the page</param>
    /// <response code="200">List of ScooterResponses</response>
    [ProducesResponseType(typeof(IEnumerable<ScooterResponse>), 200)]
    [Authorize(Policy = AppScopes.ScootersRead)]
    [HttpGet("")]
    public async Task<IEnumerable<ScooterResponse>> GetScooters([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var scooters = await scooterService.GetScooters(offset, limit);
        var response = mapper.Map<IEnumerable<ScooterResponse>>(scooters);

        return response;
    }

    /// <summary>
    /// Get scooters by Id
    /// </summary>
    /// <response code="200">ScooterResponse></response>
    [ProducesResponseType(typeof(ScooterResponse), 200)]
    [Authorize(Policy = AppScopes.ScootersRead)]
    [HttpGet("{id}")]
    public async Task<ScooterResponse> GetScooterById([FromRoute] int id)
    {
        var scooter = await scooterService.GetScooter(id);
        var response = mapper.Map<ScooterResponse>(scooter);

        return response;
    }

    /// <summary>
    /// Add scooters
    /// </summary>
    [HttpPost("")]
    [Authorize(Policy = AppScopes.ScootersWrite)]
    public async Task<ScooterResponse> AddScooter([FromBody] AddScooterRequest request)
    {
        var model = mapper.Map<AddScooterModel>(request);
        var scooter = await scooterService.AddScooter(model);
        var response = mapper.Map<ScooterResponse>(scooter);

        return response;
    }

    /// <summary>
    /// Update scooters by Id
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Policy = AppScopes.ScootersWrite)]
    public async Task<IActionResult> UpdateScooter([FromRoute] int id, [FromBody] UpdateScooterRequest request)
    {
        var model = mapper.Map<UpdateScooterModel>(request);
        await scooterService.UpdateScooter(id, model);

        return Ok();
    }

    /// <summary>
    /// Delete scooters by Id
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Policy = AppScopes.ScootersWrite)]
    public async Task<IActionResult> DeleteScooter([FromRoute] int id)
    {
        await scooterService.DeleteScooter(id);

        return Ok();
    }
}
