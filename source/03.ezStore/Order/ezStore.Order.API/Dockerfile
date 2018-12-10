FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 03.ezStore/Order/ezStore.Order.API/ezStore.Order.API.csproj 03.ezStore/Order/ezStore.Order.API/
RUN dotnet restore 03.ezStore/Order/ezStore.Order.API/ezStore.Order.API.csproj
COPY . .
WORKDIR /src/03.ezStore/Order/ezStore.Order.API
RUN dotnet build ezStore.Order.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ezStore.Order.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ezStore.Order.API.dll"]
