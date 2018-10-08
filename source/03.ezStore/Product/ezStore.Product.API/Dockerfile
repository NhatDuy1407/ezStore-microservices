FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY 03.ezStore/Product/ezStore.Product.API/ezStore.Product.API.csproj 03.ezStore/Product/ezStore.Product.API/
RUN dotnet restore 03.ezStore/Product/ezStore.Product.API/ezStore.Product.API.csproj
COPY . .
WORKDIR /src/03.ezStore/Product/ezStore.Product.API
RUN dotnet build ezStore.Product.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ezStore.Product.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ezStore.Product.API.dll"]
