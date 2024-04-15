# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER $APP_UID
# WORKDIR /app
# EXPOSE 8080
# EXPOSE 8081

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src
# COPY ["walk-in-portal_Backend/walk-in-portal_Backend.csproj", "walk-in-portal_Backend/"]
# RUN dotnet restore "walk-in-portal_Backend/walk-in-portal_Backend.csproj"
# COPY . .
# WORKDIR "/src/walk-in-portal_Backend"
# RUN dotnet build "walk-in-portal_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "walk-in-portal_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "walk-in-portal_Backend.dll"]
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Copy the csproj and restore all of the nugets
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AppDemo.dll"]