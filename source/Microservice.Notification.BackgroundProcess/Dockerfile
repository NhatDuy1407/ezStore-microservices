FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Microservice.Notification.BackgroundProcess/Microservice.Notification.BackgroundProcess.csproj Microservice.Notification.BackgroundProcess/
RUN dotnet restore Microservice.Notification.BackgroundProcess/Microservice.Notification.BackgroundProcess.csproj
COPY . .
WORKDIR /src/Microservice.Notification.BackgroundProcess
RUN dotnet build Microservice.Notification.BackgroundProcess.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Notification.BackgroundProcess.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Notification.BackgroundProcess.dll"]
