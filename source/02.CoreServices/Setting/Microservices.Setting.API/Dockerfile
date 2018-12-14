FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 03.Microservices/Setting/Microservices.Setting.API/Microservices.Setting.API.csproj 03.Microservices/Setting/Microservices.Setting.API/
RUN dotnet restore 03.Microservices/Setting/Microservices.Setting.API/Microservices.Setting.API.csproj
COPY . .
WORKDIR /src/03.Microservices/Setting/Microservices.Setting.API
RUN dotnet build Microservices.Setting.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.Setting.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.Setting.API.dll"]
