FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Notification/Microservices.Notification.BackgroundProcess/Microservices.Notification.BackgroundProcess.csproj 02.CoreServices/Notification/Microservices.Notification.BackgroundProcess/
COPY 02.CoreServices/Microservices.SharedEvents/Microservices.SharedEvents.csproj 02.CoreServices/Microservices.SharedEvents/
COPY 01.Libraries/Microservices.Core/Microservices.Core.csproj 01.Libraries/Microservices.Core/
COPY 01.Libraries/Microservices.Core.MessageQueue/Microservices.Core.MessageQueue.csproj 01.Libraries/Microservices.Core.MessageQueue/
RUN dotnet restore 02.CoreServices/Notification/Microservices.Notification.BackgroundProcess/Microservices.Notification.BackgroundProcess.csproj
COPY . .
WORKDIR /src/02.CoreServices/Notification/Microservices.Notification.BackgroundProcess
RUN dotnet build Microservices.Notification.BackgroundProcess.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.Notification.BackgroundProcess.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.Notification.BackgroundProcess.dll"]
