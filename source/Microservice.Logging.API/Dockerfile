FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Microservice.Logging.API/Microservice.Logging.API.csproj Microservice.Logging.API/
COPY Microservice.Logging.Persistence.Model/Microservice.Logging.Persistence.Model.csproj Microservice.Logging.Persistence.Model/
COPY Microservice.Core/Microservice.Core.csproj Microservice.Core/
COPY Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj Microservice.Core.DataAccess/
COPY Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj Microservice.Core.DataAccess.MongoDB/
RUN dotnet restore Microservice.Logging.API/Microservice.Logging.API.csproj
COPY . .
WORKDIR /src/Microservice.Logging.API
RUN dotnet build Microservice.Logging.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Logging.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Logging.API.dll"]
