FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend.Web/Backend.Web.csproj", "Backend.Web/"]
COPY ["Backend.Entities/Backend.Entities.csproj", "Backend.Entities/"]
COPY ["Backend.Repository/Backend.Repository.csproj", "Backend.Repository/"]
RUN dotnet restore "Backend.Web/Backend.Web.csproj"
COPY . .
WORKDIR "/src/Backend.Web"
RUN dotnet build "Backend.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Web.dll"]
