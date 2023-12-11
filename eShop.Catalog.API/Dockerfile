FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eShop.Catalog.API/eShop.Catalog.API.csproj", "eShop.Catalog.API/"]
COPY ["eShop.Catalog.Domain/eShop.Catalog.Domain.csproj", "eShop.Catalog.Domain/"]
COPY ["eShop.Common/eShop.Common.csproj", "eShop.Common/"]
COPY ["eShop.Catalog.Application/eShop.Catalog.Application.csproj", "eShop.Catalog.Application/"]
COPY ["eShop.Catalog.Infrastructure/eShop.Catalog.Infrastructure.csproj", "eShop.Catalog.Infrastructure/"]
RUN dotnet restore "eShop.Catalog.API/eShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/eShop.Catalog.API"
RUN dotnet build "eShop.Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "eShop.Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.Catalog.API.dll"]
