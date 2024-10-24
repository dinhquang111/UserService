FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /appsrc

COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY *.sln ./
COPY src/*/*.csproj ./src/
WORKDIR /appsrc/src
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
WORKDIR /appsrc
RUN dotnet restore

COPY src/. src/
RUN echo "Data in application folder" & ls src/Application/

RUN dotnet build "UserService.sln" -c $BUILD_CONFIGURATION 
RUN dotnet publish "UserService.sln" -c $BUILD_CONFIGURATION

FROM base AS final
COPY --from=build /app/publish .
RUN echo "Data in application folder" & ls /app
ENTRYPOINT ["dotnet", "UserService.Api.dll"]
