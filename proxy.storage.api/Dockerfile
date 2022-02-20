FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["proxy.storage.api/proxy.storage.api.csproj", "proxy.storage.api/"]
RUN dotnet restore "proxy.storage.api/proxy.storage.api.csproj"
COPY . .
WORKDIR "/src/proxy.storage.api"
RUN dotnet build "proxy.storage.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "proxy.storage.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "proxy.storage.api.dll"]
