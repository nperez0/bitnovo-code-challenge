FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Banking.Api/Banking.Api.csproj", "Banking.Api/"]
RUN dotnet restore "Banking.Api/Banking.Api.csproj"
COPY . .
WORKDIR "/src/Banking.Api"
RUN dotnet build "Banking.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Banking.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Bitnovo.Banking.Api.dll"]