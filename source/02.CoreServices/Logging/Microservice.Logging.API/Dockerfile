FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Logging/Microservice.Logging.API/Microservice.Logging.API.csproj 02.CoreServices/Logging/Microservice.Logging.API/
COPY 02.CoreServices/Logging/Microservice.Logging.Persistence.Model/Microservice.Logging.Persistence.Model.csproj 02.CoreServices/Logging/Microservice.Logging.Persistence.Model/
COPY 01.Libraries/Microservice.Core/Microservice.Core.csproj 01.Libraries/Microservice.Core/
COPY 01.Libraries/Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj 01.Libraries/Microservice.Core.DataAccess.MongoDB/
COPY 01.Libraries/Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj 01.Libraries/Microservice.Core.DataAccess/
COPY 02.CoreServices/Logging/Microservice.Logging.Domain/Microservice.Logging.Domain.csproj 02.CoreServices/Logging/Microservice.Logging.Domain/
RUN dotnet restore 02.CoreServices/Logging/Microservice.Logging.API/Microservice.Logging.API.csproj
COPY . .
WORKDIR /src/02.CoreServices/Logging/Microservice.Logging.API
RUN dotnet build Microservice.Logging.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Logging.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Logging.API.dll"]
