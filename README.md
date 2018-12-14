# A microservicess system built on .NET Core (in-progress)

## Technologies and frameworks used:
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
- DDD
- CLEAN architecture

## IDE
- Visual Studio Community 2017
- Visual Studio Code

## Local Development
- First run `docker-compose -f docker-compose.init.yml up` to start databases and queues
- Wait for databases and queues ready
- Run application from Visual Studio.
- Run Angular6 project from `source\03.ezStoreWebUI`. Note: I am using port 7001
- If you want to deploy Angular project to docker, build project `ng build --prod` then run `docker-compose -f docker-compose-webui.yml up`

## Local Kubenetes Deployment 
- First run `k8s\01-build-db.bat`, this will build images for databases and queues then push to Docker repository (optional: if images are already there)
- Deploy databases and queue to Kubenetes by running `k8s\02-deploy-db.bat`
- Run `k8s\03-build-api.bat` to build and publish API image
- Deploy API to Kubenetes by running `k8s\04-deploy-api.bat`
- Run `k8s\05-build-webui.bat` to build WebUI image
- Run `k8s\06-publish-webui-image.bat` to publish WebUI image
- Deploy WebUI to Kubenetes by running `k8s\07-deploy-webui.bat`

## Istio Dashboard (Application metric & health check)
- Download Istio from https://github.com/istio/istio/releases/
- From Istio folder, run `kubectl apply -f install/kubernetes/istio-demo.yaml`
- Waiting for Istio ready, run Istio Dashboard: `kubectl -n istio-system port-forward $(kubectl -n istio-system get pod -l app=grafana -o jsonpath='{.items[0].metadata.name}') 3000:3000 &` and open http://localhost:3000
- Run `k8s\istio-03-rules.bat` to allow Istio Service to connect database from outside 
- Run 'k8s\istio-04-gateway.bat' to allow run API from domain name http://microservices.identityserver:30001/
- Run `k8s\istio-05-setup-api.bat` to set up API with injected Istio sidecar
- Run `kubectl -n istio-system port-forward istio-egressgateway-56bdd5fcfb-rxbzs 30001` to forward port 30001. (`istio-egressgateway-56bdd5fcfb-rxbzs` is istio-egressgateway)
- Open site http://microservices.identityserver:30001/ and check activity from http://localhost:3000 

## Microservicess
- Identity Server
- Logging Service
- Notification Service
- Product

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