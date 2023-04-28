using RentScooter.Context;
using RentScooter.Identity;
using RentScooter.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();

services.RegisterAppServices();

services.AddIS4();


var app = builder.Build();

app.UseAppHealthChecks();

app.UseIS4();


app.Run();