FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SafaricomHackathonQ2.API/SafaricomHackathonQ2.API.csproj", "SafaricomHackathonQ2.API/"]
COPY ["SafaricomHackathonQ2.Logig/SafaricomHackathonQ2.Logic.csproj", "SafaricomHackathonQ2.Logig/"]
COPY ["SafaricomHackathonQ2.Data/SafaricomHackathonQ2.Data.csproj", "SafaricomHackathonQ2.Data/"]
RUN dotnet restore "SafaricomHackathonQ2.API/SafaricomHackathonQ2.API.csproj"
COPY . .
WORKDIR "/src/SafaricomHackathonQ2.API"
RUN dotnet build "SafaricomHackathonQ2.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SafaricomHackathonQ2.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SafaricomHackathonQ2.API.dll"]
