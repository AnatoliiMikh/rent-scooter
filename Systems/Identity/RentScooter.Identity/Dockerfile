#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Identity/RentScooter.Identity/RentScooter.Identity.csproj", "Systems/Identity/RentScooter.Identity/"]
COPY ["Data/RentScooter.Context.Entities/RentScooter.Context.Entities.csproj", "Data/RentScooter.Context.Entities/"]
COPY ["Data/RentScooter.Context/RentScooter.Context.csproj", "Data/RentScooter.Context/"]
COPY ["Shared/RentScooter.Settings/RentScooter.Settings.csproj", "Shared/RentScooter.Settings/"]
COPY ["Shared/RentScooter.Common/RentScooter.Common.csproj", "Shared/RentScooter.Common/"]
RUN dotnet restore "Systems/Identity/RentScooter.Identity/RentScooter.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/RentScooter.Identity"
RUN dotnet build "RentScooter.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentScooter.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentScooter.Identity.dll"]