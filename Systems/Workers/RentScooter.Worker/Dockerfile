#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Workers/RentScooter.Worker/RentScooter.Worker.csproj", "Systems/Workers/RentScooter.Worker/"]
COPY ["Data/RentScooter.Context/RentScooter.Context.csproj", "Data/RentScooter.Context/"]
COPY ["Shared/RentScooter.Settings/RentScooter.Settings.csproj", "Shared/RentScooter.Settings/"]
COPY ["Data/RentScooter.Context.Entities/RentScooter.Context.Entities.csproj", "Data/RentScooter.Context.Entities/"]
COPY ["Services/RentScooter.Services.Actions/RentScooter.Services.Actions.csproj", "Services/RentScooter.Services.Actions/"]
COPY ["Shared/RentScooter.Consts/RentScooter.Consts.csproj", "Shared/RentScooter.Consts/"]
COPY ["Services/RentScooter.Services.EmailSender/RentScooter.Services.EmailSender.csproj", "Services/RentScooter.Services.EmailSender/"]
COPY ["Services/RentScooter.Services.RabbitMq/RentScooter.Services.RabbitMq.csproj", "Services/RentScooter.Services.RabbitMq/"]
COPY ["Shared/RentScooter.Common/RentScooter.Common.csproj", "Shared/RentScooter.Common/"]
RUN dotnet restore "Systems/Workers/RentScooter.Worker/RentScooter.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Workers/RentScooter.Worker"
RUN dotnet build "RentScooter.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentScooter.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentScooter.Worker.dll"]