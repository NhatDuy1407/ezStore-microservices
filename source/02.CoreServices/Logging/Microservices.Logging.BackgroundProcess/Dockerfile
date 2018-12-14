FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Logging/Microservices.Logging.BackgroundProcess/Microservices.Logging.BackgroundProcess.csproj 02.CoreServices/Logging/Microservices.Logging.BackgroundProcess/
COPY 02.CoreServices/Logging/Microservices.Logging.Persistence.Model/Microservices.Logging.Persistence.Model.csproj 02.CoreServices/Logging/Microservices.Logging.Persistence.Model/
COPY 01.Libraries/Microservices.Core/Microservices.Core.csproj 01.Libraries/Microservices.Core/
COPY 01.Libraries/Microservices.Core.DataAccess.MongoDB/Microservices.Core.DataAccess.MongoDB.csproj 01.Libraries/Microservices.Core.DataAccess.MongoDB/
COPY 01.Libraries/Microservices.Core.DataAccess/Microservices.Core.DataAccess.csproj 01.Libraries/Microservices.Core.DataAccess/
COPY 02.CoreServices/Microservices.SharedEvents/Microservices.SharedEvents.csproj 02.CoreServices/Microservices.SharedEvents/
COPY 01.Libraries/Microservices.Core.MessageQueue/Microservices.Core.MessageQueue.csproj 01.Libraries/Microservices.Core.MessageQueue/
RUN dotnet restore 02.CoreServices/Logging/Microservices.Logging.BackgroundProcess/Microservices.Logging.BackgroundProcess.csproj
COPY . .
WORKDIR /src/02.CoreServices/Logging/Microservices.Logging.BackgroundProcess
RUN dotnet build Microservices.Logging.BackgroundProcess.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.Logging.BackgroundProcess.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.Logging.BackgroundProcess.dll"]
