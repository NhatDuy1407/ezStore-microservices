FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ezStore.Microservice.Product.API/ezStore.Microservice.Product.API.csproj", "ezStore.Microservice.Product.API/"]
RUN dotnet restore "ezStore.Microservice.Product.API/ezStore.Microservice.Product.API.csproj"
COPY . .
WORKDIR "/src/ezStore.Microservice.Product.API"
RUN dotnet build "ezStore.Microservice.Product.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ezStore.Microservice.Product.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ezStore.Microservice.Product.API.dll"]