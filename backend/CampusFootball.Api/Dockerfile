FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["backend/CampusFootball.Api/CampusFootball.Api.csproj", "backend/CampusFootball.Api/"]
RUN dotnet restore "backend/CampusFootball.Api/CampusFootball.Api.csproj"
COPY . .
WORKDIR "/src/backend/CampusFootball.Api"
RUN dotnet build "CampusFootball.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CampusFootball.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CampusFootball.Api.dll"]
