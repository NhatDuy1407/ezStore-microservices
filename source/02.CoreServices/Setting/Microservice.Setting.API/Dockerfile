FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY 03.Microservice/Setting/Microservice.Setting.API/Microservice.Setting.API.csproj 03.Microservice/Setting/Microservice.Setting.API/
RUN dotnet restore 03.Microservice/Setting/Microservice.Setting.API/Microservice.Setting.API.csproj
COPY . .
WORKDIR /src/03.Microservice/Setting/Microservice.Setting.API
RUN dotnet build Microservice.Setting.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.Setting.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Setting.API.dll"]
