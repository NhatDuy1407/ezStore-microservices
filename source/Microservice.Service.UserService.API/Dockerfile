FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Microservice.Service.UserService.API/Microservice.Service.UserService.API.csproj Microservice.Service.UserService.API/
COPY Microservice.Core.CachingService/Microservice.Core.CachingService.csproj Microservice.Core.CachingService/
COPY Microservice.Core.Service/Microservice.Core.Service.csproj Microservice.Core.Service/
COPY Microservice.Service.UserService/Microservice.Service.UserService.csproj Microservice.Service.UserService/
COPY Microservice.Core/Microservice.Core.csproj Microservice.Core/
COPY Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj Microservice.Core.DataAccess/
COPY Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj Microservice.Core.DataAccess.MongoDB/
RUN dotnet restore
COPY . .
WORKDIR /src/Microservice.Service.UserService.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.Service.UserService.API.dll"]
