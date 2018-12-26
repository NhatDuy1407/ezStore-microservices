FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/FileSystem/Microservices.FileSystem.API/Microservices.FileSystem.API.csproj 02.CoreServices/FileSystem/Microservices.FileSystem.API/
COPY 02.CoreServices/FileSystem/Microservices.FileSystem.Persistence.Model/Microservices.FileSystem.Persistence.Model.csproj 02.CoreServices/FileSystem/Microservices.FileSystem.Persistence.Model/
COPY 01.Libraries/Microservices.Core/Microservices.Core.csproj 01.Libraries/Microservices.Core/
COPY 01.Libraries/Microservices.Core.DataAccess.MongoDB/Microservices.Core.DataAccess.MongoDB.csproj 01.Libraries/Microservices.Core.DataAccess.MongoDB/
COPY 01.Libraries/Microservices.Core.DataAccess/Microservices.Core.DataAccess.csproj 01.Libraries/Microservices.Core.DataAccess/
COPY 02.CoreServices/FileSystem/Microservices.FileSystem.Domain/Microservices.FileSystem.Domain.csproj 02.CoreServices/FileSystem/Microservices.FileSystem.Domain/
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
