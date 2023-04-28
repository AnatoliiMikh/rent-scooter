#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Workers/RentScooter.Worker/RentScooter.Worker.csproj", "Systems/Workers/RentScooter.Worker/"]
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