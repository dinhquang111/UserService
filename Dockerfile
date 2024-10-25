FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY Directory.*.props .
COPY src/*/*.csproj ./src/
WORKDIR /app/src
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore Api/Api.csproj
WORKDIR /app
COPY src/. src/
RUN dotnet build "src/Api/Api.csproj" -c $BUILD_CONFIGURATION --no-restore
RUN dotnet publish "src/Api/Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserService.Api.dll"]
