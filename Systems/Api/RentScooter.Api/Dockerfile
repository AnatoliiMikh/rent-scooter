#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/RentScooter.Api/RentScooter.Api.csproj", "Systems/Api/RentScooter.Api/"]
COPY ["Data/RentScooter.Context/RentScooter.Context.csproj", "Data/RentScooter.Context/"]
COPY ["Shared/RentScooter.Settings/RentScooter.Settings.csproj", "Shared/RentScooter.Settings/"]
COPY ["Data/RentScooter.Context.Entities/RentScooter.Context.Entities.csproj", "Data/RentScooter.Context.Entities/"]
COPY ["Data/Migrations/RentScooter.Context.MigrationsMSSQL/RentScooter.Context.MigrationsMSSQL.csproj", "Data/Migrations/RentScooter.Context.MigrationsMSSQL/"]
COPY ["Data/Migrations/RentScooter.Context.MigrationsPostgreSQL/RentScooter.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/RentScooter.Context.MigrationsPostgreSQL/"]
COPY ["Services/RentScooter.Services.Actions/RentScooter.Services.Actions.csproj", "Services/RentScooter.Services.Actions/"]
COPY ["Shared/RentScooter.Consts/RentScooter.Consts.csproj", "Shared/RentScooter.Consts/"]
COPY ["Services/RentScooter.Services.EmailSender/RentScooter.Services.EmailSender.csproj", "Services/RentScooter.Services.EmailSender/"]
COPY ["Services/RentScooter.Services.RabbitMq/RentScooter.Services.RabbitMq.csproj", "Services/RentScooter.Services.RabbitMq/"]
COPY ["Services/RentScooter.Services.Brands/RentScooter.Services.Brands.csproj", "Services/RentScooter.Services.Brands/"]
COPY ["Services/RentScooter.Services.Cache/RentScooter.Services.Cache.csproj", "Services/RentScooter.Services.Cache/"]
COPY ["Shared/RentScooter.Common/RentScooter.Common.csproj", "Shared/RentScooter.Common/"]
COPY ["Services/RentScooter.Services.Scooters/RentScooter.Services.Scooters.csproj", "Services/RentScooter.Services.Scooters/"]
COPY ["Services/RentScooter.Services.Settings/RentScooter.Services.Settings.csproj", "Services/RentScooter.Services.Settings/"]
COPY ["Services/RentScooter.Services.UserAccount/RentScooter.Services.UserAccount.csproj", "Services/RentScooter.Services.UserAccount/"]
COPY ["Systems/Api/RentScooter.Api.Settings/RentScooter.Api.Settings.csproj", "Systems/Api/RentScooter.Api.Settings/"]
RUN dotnet restore "Systems/Api/RentScooter.Api/RentScooter.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/RentScooter.Api"
RUN dotnet build "RentScooter.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentScooter.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentScooter.Api.dll"]