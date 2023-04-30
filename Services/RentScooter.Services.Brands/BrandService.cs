namespace RentScooter.Services.Brands;

using AutoMapper;
using RentScooter.Context;
using Microsoft.EntityFrameworkCore;

public class BrandService : IBrandService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public BrandService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<BrandModel>> GetBrands()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Brands = context
            .Brands
            .AsQueryable();

        var data = (await Brands.ToListAsync()).Select(Brand => mapper.Map<BrandModel>(Brand));

        return data;
    }
}
