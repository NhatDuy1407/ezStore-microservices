# A microservices system built on .NET Core (in-progress)

## Technologies and frameworks used:
- DDD
- CLEAN architecture
- ASP.NET MVC Core 2.2
- Microsoft.EntityFrameworkCore (2.2)
- IdentityServer4 (2.1.1)
- Angular6
- CoreUI
- mysql (5.7)
- mongo (4.1.1)
- rabbitmq (3.7)
- Docker-ce (version 18.06.1-ce, build e68fc7a)
- Kubenetes (1.10.3)
- Istio-1.0.5

## IDE
- Visual Studio Community 2017
- Visual Studio Code

## Local Development
- First run `docker-compose -f docker-compose.init.yml up` to start databases and queues
- Wait for databases and queues ready
- Run application from Visual Studio.
- Run Angular6 project from `source\03.ezStoreWebUI` by `npm start`. Note: I am using port 7001
- If you want to deploy Angular project to docker, build project `ng build --prod` then run `docker-compose -f docker-compose-webui.yml up`
- Open IdentityServer: http://localhost:5001, http://localhost:5001/swagger
- Open Logging Api: http://localhost:5002/swagger
- Open Setting Api: http://localhost:5003/swagger
- Open Order Api: http://localhost:6001/swagger
- Open Payment Api: http://localhost:6002/swagger
- Open Product Api: http://localhost:6003/swagger
- Open Warehouse Api: http://localhost:6004/swagger
- Open WebUI: http://localhost:7001
- Use IdentityServer: http://localhost:5001 to create a user, then login by WebUI: http://localhost:7001 to get `token` in `localstorage`
- Use `token` as `Bearer Authentication` for ``Swagger`

## Local Kubenetes Deployment 
- (If you want to update Docker Repository) Login Docker Repository by DockerId: ezstoremicroservices   Password: 8dh&^5D@@
- (If you want to update Docker Repository) Run `k8s\01-build-db.bat`, this will build images for databases and queues then push to Docker repository (optional: if images are already there)
- Deploy databases and queue to Kubenetes by running `k8s\02-deploy-db.bat`
- (If you want to update Docker Repository) Run `k8s\03-build-api.bat` to build and publish API image
- Deploy API to Kubenetes by running `k8s\04-deploy-api.bat`
- (If you want to update Docker Repository) Run `k8s\05-build-webui.bat` to build WebUI image then run `k8s\06-publish-webui-image.bat` to publish WebUI image
- Deploy WebUI to Kubenetes by running `k8s\07-deploy-webui.bat`
- Run command: `kubectl get all` to determine runtime port of each services
- Open IdentityServer: http://localhost:30101, http://localhost:30101/swagger
- Open Logging Api: http://localhost:30102/swagger
- Open Setting Api: http://localhost:30103/swagger
- Open Order Api: http://localhost:30201/swagger
- Open Payment Api: http://localhost:30202/swagger
- Open Product Api: http://localhost:30203/swagger
- Open Warehouse Api: http://localhost:30204/swagger

## Istio Dashboard (Application metric & health check)
- Download Istio from https://github.com/istio/istio/releases/. I am using version 1.0.5
- From Istio folder, run `kubectl apply -f install/kubernetes/istio-demo.yaml`
- Add `\istio-1.0.5\bin` absolute path into `PATH` in `Environment Variables`
- Waiting for Istio ready, run Istio Dashboard: `kubectl -n istio-system port-forward $(kubectl -n istio-system get pod -l app=grafana -o jsonpath='{.items[0].metadata.name}') 4001:3000 &` and open http://localhost:4001
- Run `k8s\istio-03-rules.bat` to allow Istio Service to connect database from outside 
- Open `hosts` file, add custom DNS:
  - 127.0.0.1 microservices.identityserver 
  - 127.0.0.1 microservices.logging
  - 127.0.0.1 ezstore.orderapi
  - 127.0.0.1 ezstore.paymentapi
  - 127.0.0.1 ezstore.productapi
  - 127.0.0.1 ezstore.warehouseapi
- Run 'k8s\istio-04-gateway.bat' to allow run API from domain name http://microservices.identityserver:30101/
- Run `k8s\istio-05-setup-api.bat` to set up API with injected Istio sidecar. (`istio-ingressgateway-64cb7d5f6d-mntg6` is istio-egressgateway, please replace from your machine)
- Open site http://microservices.identityserver:30101/ and check activity from http://localhost:4001 
- (updating...)

## Microservices
- Identity Server
- Logging Service
- Notification Service
- Setting Service
- Product Service

## Entity Framework Migration
- Implement database structure in ezStore.Product.Infrastructure: Entities and DbContext
- Implement code to run migration in `DatabaseInitialization.cs`
- From `ezStore.Product.API`, register service:

`services.AddDbContext<ApplicationDbContext>(options => 
                options.UseMySql(Configuration.GetConnectionString(MicroservicesConstants.DefaultConnection), b => b.MigrationsAssembly("ezStore.Product.API")));`
- Add migration:
    - From Visual Studio run command: `Add-Migration Initial`
    - Or, run command line: `dotnet ef migrations add Initial`
- Call DatabaseInitialize from Program.cs

## Contributing
- Fork the repo on GitHub
- Clone the project to your own machine
- Commit changes to your own branch
- Push your work back up to your fork
- Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!
