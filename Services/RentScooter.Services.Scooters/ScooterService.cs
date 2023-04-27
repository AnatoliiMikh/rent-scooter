namespace RentScooter.Services.Scooters;

using AutoMapper;
using RentScooter.Context;
using Microsoft.EntityFrameworkCore;

public class ScooterService : IScooterService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public ScooterService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ScooterModel>> GetScooters()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Scooters = context
            .Scooters
            .AsQueryable();

        var data = (await Scooters.ToListAsync()).Select(Scooter => mapper.Map<ScooterModel>(Scooter));

        return data;
    }
}
