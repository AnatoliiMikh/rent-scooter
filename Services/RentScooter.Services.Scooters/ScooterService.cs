namespace RentScooter.Services.Scooters;

using AutoMapper;
using RentScooter.Common.Exceptions;
using RentScooter.Common.Validator;
using RentScooter.Context;
using RentScooter.Context.Entities;
using RentScooter.Services.Cache;
using Microsoft.EntityFrameworkCore;
//using RentScooter.Services.Actions;
//using RentScooter.Services.EmailSender;
//using RentScooter.Services.UserAccount;

public class ScooterService : IScooterService
{
    private const string contextCacheKey = "scooters_cache_key";

    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
   //private readonly IAction action;
    private readonly ICacheService cacheService;
    private readonly IModelValidator<AddScooterModel> addScooterModelValidator;
    private readonly IModelValidator<UpdateScooterModel> updateScooterModelValidator;
    //private readonly IModelValidator<RegisterUserAccountModelValidator> registerUserAccountModelValidator;

    public ScooterService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        //IAction action,
        ICacheService cacheService,
        IModelValidator<AddScooterModel> addScooterModelValidator,
        IModelValidator<UpdateScooterModel> updateScooterModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        //this.action = action;
        this.cacheService = cacheService;
        this.addScooterModelValidator = addScooterModelValidator;
        this.updateScooterModelValidator = updateScooterModelValidator;
    }

    public async Task<IEnumerable<ScooterModel>> GetScooters(int offset = 0, int limit = 10)
    {
        try
        {
            var cached_data = await cacheService.Get<IEnumerable<ScooterModel>>(contextCacheKey);
            if (cached_data != null)
                return cached_data;
        }
        catch
        {
            // Put log message here
        }

        await Task.Delay(5000);




        using var context = await contextFactory.CreateDbContextAsync();

        var scooters = context
            .Scooters
            .Include(x => x.Brand)
            .AsQueryable();

        scooters = scooters
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await scooters.ToListAsync()).Select(scooter => mapper.Map<ScooterModel>(scooter));

        await cacheService.Put(contextCacheKey, data, TimeSpan.FromSeconds(30));

        return data;
    }

    public async Task<ScooterModel> GetScooter(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var scooter = await context.Scooters.Include(x => x.Brand).FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<ScooterModel>(scooter);

        return data;
    }
    public async Task<ScooterModel> AddScooter(AddScooterModel model)
    {
        addScooterModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var scooter = mapper.Map<Scooter>(model);
        await context.Scooters.AddAsync(scooter);
        context.SaveChanges();


        await cacheService.Delete(contextCacheKey); //удаляем кэш после добавления нового самоката

        return mapper.Map<ScooterModel>(scooter);
    }

    //public async Task UpdateScooter(int scooterId, UpdateScooterModel model)
    //{
    //    updateScooterModelValidator.Check(model);

    //    using var context = await contextFactory.CreateDbContextAsync();

    //    var scooter = await context.Scooters.FirstOrDefaultAsync(x => x.Id.Equals(scooterId));

    //    ProcessException.ThrowIf(() => scooter is null, $"The scooter (id: {scooterId}) was not found");

    //    scooter = mapper.Map(model, scooter);

    //    context.Scooters.Update(scooter);
    //    context.SaveChanges();
    //}
    //Пробую создать новый таск UpdateScooter:
    public async Task UpdateScooter(int scooterId, UpdateScooterModel model)
    {
        updateScooterModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var scooter = await context.Scooters.FirstOrDefaultAsync(x => x.Id.Equals(scooterId));

        ProcessException.ThrowIf(() => scooter is null, $"The scooter (id: {scooterId}) was not found");

        //if (scooter.IsInUse)
        //{
        //    await action.SendStartRentEmail(new EmailModel
        //    {
        //        //Email = model.Email,
        //        Email = UserAccountModel.Email,
        //        Subject = "RentScooter notification",
        //        Message = "Scooter rented"
        //    });
        //}

        scooter = mapper.Map(model, scooter);

        context.Scooters.Update(scooter);
        context.SaveChanges();
    }



    public async Task DeleteScooter(int scooterId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var scooter = await context.Scooters.FirstOrDefaultAsync(x => x.Id.Equals(scooterId))
            ?? throw new ProcessException($"The scooter (id: {scooterId}) was not found");

        context.Remove(scooter);
        context.SaveChanges();
    }
}
