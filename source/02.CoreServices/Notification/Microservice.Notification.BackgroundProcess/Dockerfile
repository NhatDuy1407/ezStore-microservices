FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Notification/Microservice.Notification.BackgroundProcess/Microservice.Notification.BackgroundProcess.csproj 02.CoreServices/Notification/Microservice.Notification.BackgroundProcess/
COPY 02.CoreServices/Microservice.SharedEvents/Microservice.SharedEvents.csproj 02.CoreServices/Microservice.SharedEvents/
COPY 01.Libraries/Microservice.Core/Microservice.Core.csproj 01.Libraries/Microservice.Core/
COPY 01.Libraries/Microservice.Core.MessageQueue/Microservice.Core.MessageQueue.csproj 01.Libraries/Microservice.Core.MessageQueue/
RUN dotnet restore 02.CoreServices/Notification/Microservice.Notification.BackgroundProcess/Microservice.Notification.BackgroundProcess.csproj
COPY . .
WORKDIR /src/02.CoreServices/Notification/Microservice.Notification.BackgroundProcess
RUN dotnet build Microservice.Notification.BackgroundProcess.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Notification.BackgroundProcess.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Notification.BackgroundProcess.dll"]
