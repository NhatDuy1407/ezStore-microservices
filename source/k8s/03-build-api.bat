dotnet publish ezStoreMicroservice.sln
docker-compose -f docker-compose.k8s.yml build 

docker tag microservice.identityserver khainx127/microservice.identityserver
docker push khainx127/microservice.identityserver

docker tag microservice.logging.api khainx127/microservice.logging.api
docker push khainx127/microservice.logging.api

docker tag microservice.logging.background khainx127/microservice.logging.background
docker push khainx127/microservice.logging.background

docker tag microservice.notification.background khainx127/microservice.notification.background
docker push khainx127/microservice.notification.background

docker tag ezstore.order.api khainx127/ezstore.order.api
docker push khainx127/ezstore.order.api

docker tag ezstore.payment.api khainx127/ezstore.payment.api
docker push khainx127/ezstore.payment.api

docker tag ezstore.product.api khainx127/ezstore.product.api
docker push khainx127/ezstore.product.api

docker tag ezstore.warehouse.api khainx127/ezstore.warehouse.api
docker push khainx127/ezstore.warehouse.api
