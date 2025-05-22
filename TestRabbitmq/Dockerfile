
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestRabbitmq/TestRabbitmq.csproj", "TestRabbitmq/"]
RUN dotnet restore "./TestRabbitmq/./TestRabbitmq.csproj"
COPY . .
WORKDIR "/src/TestRabbitmq"
RUN dotnet build "./TestRabbitmq.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestRabbitmq.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestRabbitmq.dll"]