FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Microservice.Logging.BackgroundProcess/Microservice.Logging.BackgroundProcess.csproj Microservice.Logging.BackgroundProcess/
RUN dotnet restore
COPY . .
WORKDIR /src/Microservice.Logging.BackgroundProcess
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Logging.BackgroundProcess.dll"]
