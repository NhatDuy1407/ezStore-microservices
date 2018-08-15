FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Microservice.Logging.BackgroundProcess/Microservice.Logging.BackgroundProcess.csproj Microservice.Logging.BackgroundProcess/
COPY Microservice.Core.CachingService/Microservice.Core.CachingService.csproj Microservice.Core.CachingService/
COPY Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj Microservice.Core.DataAccess/
COPY Microservice.Core/Microservice.Core.csproj Microservice.Core/
COPY Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj Microservice.Core.DataAccess.MongoDB/
COPY Microservice.Logging.Persistence.Model/Microservice.Logging.Persistence.Model.csproj Microservice.Logging.Persistence.Model/
COPY Microservice.Core.MessageQueue/Microservice.Core.MessageQueue.csproj Microservice.Core.MessageQueue/
COPY Microservice.SharedEvents/Microservice.SharedEvents.csproj Microservice.SharedEvents/
RUN dotnet restore Microservice.Logging.BackgroundProcess/Microservice.Logging.BackgroundProcess.csproj
COPY . .
WORKDIR /src/Microservice.Logging.BackgroundProcess
RUN dotnet build Microservice.Logging.BackgroundProcess.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Logging.BackgroundProcess.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Logging.BackgroundProcess.dll"]
