FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY 03.ezStore/WareHouse/ezStore.WareHouse.API/ezStore.WareHouse.API.csproj 03.ezStore/WareHouse/ezStore.WareHouse.API/
RUN dotnet restore 03.ezStore/WareHouse/ezStore.WareHouse.API/ezStore.WareHouse.API.csproj
COPY . .
WORKDIR /src/03.ezStore/WareHouse/ezStore.WareHouse.API
RUN dotnet build ezStore.WareHouse.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ezStore.WareHouse.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ezStore.WareHouse.API.dll"]
