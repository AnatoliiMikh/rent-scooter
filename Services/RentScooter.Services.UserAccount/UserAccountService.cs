namespace RentScooter.Services.UserAccount;

using AutoMapper;
using RentScooter.Common.Exceptions;
using RentScooter.Common.Validator;
using RentScooter.Context.Entities;
using RentScooter.Services.Actions; 
using RentScooter.Services.EmailSender; 
using Microsoft.AspNetCore.Identity;

public class UserAccountService : IUserAccountService
{
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;
    private readonly IAction action; 
    private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;

    public UserAccountService(
        IMapper mapper,
        UserManager<User> userManager,
        IAction action, 
        IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.action = action; 
        this.registerUserAccountModelValidator = registerUserAccountModelValidator;
    }

    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        registerUserAccountModelValidator.Check(model);

        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
            throw new ProcessException($"User account with email {model.Email} already exist.");

        user = new User()
        {
            Status = UserStatus.Active,
            FullName = model.Name,
            UserName = model.Email, 
            Email = model.Email,
            EmailConfirmed = true, 
            PhoneNumber = null,
            PhoneNumberConfirmed = false
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");

        await action.SendEmail(new EmailModel
        {
            Email = model.Email,
            Subject = "RentScooter notification",
            Message = "You are registered"
        });

        return mapper.Map<UserAccountModel>(user);
    }
}
