namespace RentScooter.Services.Rents;

using AutoMapper;
using RentScooter.Context;
using Microsoft.EntityFrameworkCore;

public class RentService : IRentService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public RentService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }
    public async Task<IEnumerable<RentModel>> GetRents()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Rents = context
            .Rents
            .AsQueryable();

        var data = (await Rents.ToListAsync()).Select(Rent => mapper.Map<RentModel>(Rent));

        return data;
    }
}
