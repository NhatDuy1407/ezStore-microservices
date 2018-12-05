FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Logging/Microservice.Logging.BackgroundProcess/Microservice.Logging.BackgroundProcess.csproj 02.CoreServices/Logging/Microservice.Logging.BackgroundProcess/
COPY 02.CoreServices/Logging/Microservice.Logging.Persistence.Model/Microservice.Logging.Persistence.Model.csproj 02.CoreServices/Logging/Microservice.Logging.Persistence.Model/
COPY 01.Libraries/Microservice.Core/Microservice.Core.csproj 01.Libraries/Microservice.Core/
COPY 01.Libraries/Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj 01.Libraries/Microservice.Core.DataAccess.MongoDB/
COPY 01.Libraries/Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj 01.Libraries/Microservice.Core.DataAccess/
COPY 02.CoreServices/Microservice.SharedEvents/Microservice.SharedEvents.csproj 02.CoreServices/Microservice.SharedEvents/
COPY 01.Libraries/Microservice.Core.MessageQueue/Microservice.Core.MessageQueue.csproj 01.Libraries/Microservice.Core.MessageQueue/
RUN dotnet restore 02.CoreServices/Logging/Microservice.Logging.BackgroundProcess/Microservice.Logging.BackgroundProcess.csproj
COPY . .
WORKDIR /src/02.CoreServices/Logging/Microservice.Logging.BackgroundProcess
RUN dotnet build Microservice.Logging.BackgroundProcess.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Logging.BackgroundProcess.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Logging.BackgroundProcess.dll"]
