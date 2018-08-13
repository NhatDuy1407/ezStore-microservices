FROM microsoft/dotnet:2.1.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1.2-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Microservice.Logging.API/Microservice.Logging.API.csproj Microservice.Logging.API/
RUN dotnet restore
COPY . .
WORKDIR /src/Microservice.Logging.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Logging.API.dll"]
