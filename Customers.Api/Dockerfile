FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Customers.Api/Customers.Api.csproj", "Customers.Api/"]
RUN dotnet restore "Customers.Api/Customers.Api.csproj"
COPY . .
WORKDIR "/src/Customers.Api"
RUN dotnet build "Customers.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Customers.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Bitnovo.Customers.Api.dll"]