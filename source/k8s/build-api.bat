dotnet publish ../ezStoreMicroservice.sln
docker-compose -f ../docker-compose.k8s.yml build 

docker tag microservice.identity.server khainx127/microservice.identity.server
docker push khainx127/microservice.identity.server

docker tag microservice.logging.api khainx127/microservice.logging.api
docker push khainx127/microservice.logging.api

docker tag microservice.logging.background khainx127/microservice.logging.background
docker push khainx127/microservice.logging.background

docker tag microservice.notification.background khainx127/microservice.notification.background
docker push khainx127/microservice.notification.background

docker tag ezstore.product.api khainx127/ezstore.product.api
docker push khainx127/ezstore.product.api
