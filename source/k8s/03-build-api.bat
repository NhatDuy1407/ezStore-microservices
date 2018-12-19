dotnet publish ezStoreMicroservices.sln
docker-compose -f docker-compose.k8s.yml build 

docker tag microservices.identityserver ezstoremicroservices/microservices.identityserver
docker push ezstoremicroservices/microservices.identityserver

docker tag microservices.logging.api ezstoremicroservices/microservices.logging.api
docker push ezstoremicroservices/microservices.logging.api

docker tag microservices.setting.api ezstoremicroservices/microservices.setting.api
docker push ezstoremicroservices/microservices.setting.api

docker tag microservices.logging.background ezstoremicroservices/microservices.logging.background
docker push ezstoremicroservices/microservices.logging.background

docker tag microservices.notification.background ezstoremicroservices/microservices.notification.background
docker push ezstoremicroservices/microservices.notification.background

docker tag ezstore.order.api ezstoremicroservices/ezstore.order.api
docker push ezstoremicroservices/ezstore.order.api

docker tag ezstore.payment.api ezstoremicroservices/ezstore.payment.api
docker push ezstoremicroservices/ezstore.payment.api

docker tag ezstore.product.api ezstoremicroservices/ezstore.product.api
docker push ezstoremicroservices/ezstore.product.api

docker tag ezstore.warehouse.api ezstoremicroservices/ezstore.warehouse.api
docker push ezstoremicroservices/ezstore.warehouse.api
