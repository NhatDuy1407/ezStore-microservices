FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/FileSystem/Microservices.FileSystem.API/Microservices.FileSystem.API.csproj 02.CoreServices/FileSystem/Microservices.FileSystem.API/
COPY 02.CoreServices/FileSystem/Microservices.FileSystem.ApplicationCore/Microservices.FileSystem.ApplicationCore.csproj 02.CoreServices/FileSystem/Microservices.FileSystem.ApplicationCore/
COPY 01.Libraries/Microservices.ApplicationCore/Ws4vn.Microservices.ApplicationCore.csproj 01.Libraries/Microservices.ApplicationCore/
COPY 02.CoreServices/FileSystem/Microservices.FileSystem.Infrastructure/Microservices.FileSystem.Infrastructure.csproj 02.CoreServices/FileSystem/Microservices.FileSystem.Infrastructure/
COPY 01.Libraries/Microservices.Infrastructure.MongoDB/Ws4vn.Microservices.Infrastructure.MongoDB.csproj 01.Libraries/Microservices.Infrastructure.MongoDB/
RUN dotnet restore 02.CoreServices/FileSystem/Microservices.FileSystem.API/Microservices.FileSystem.API.csproj
COPY . .
WORKDIR /src/02.CoreServices/FileSystem/Microservices.FileSystem.API
RUN dotnet build Microservices.FileSystem.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.FileSystem.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.FileSystem.API.dll"]
