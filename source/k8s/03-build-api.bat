dotnet publish ezStoreMicroservicess.sln
docker-compose -f docker-compose.k8s.yml build 

docker tag microservices.identityserver khainx127/microservices.identityserver
docker push khainx127/microservices.identityserver

docker tag microservices.logging.api khainx127/microservices.logging.api
docker push khainx127/microservices.logging.api

docker tag microservices.setting.api khainx127/microservices.setting.api
docker push khainx127/microservices.setting.api

docker tag microservices.logging.background khainx127/microservices.logging.background
docker push khainx127/microservices.logging.background

docker tag microservices.notification.background khainx127/microservices.notification.background
docker push khainx127/microservices.notification.background

docker tag ezstore.order.api khainx127/ezstore.order.api
docker push khainx127/ezstore.order.api

docker tag ezstore.payment.api khainx127/ezstore.payment.api
docker push khainx127/ezstore.payment.api

docker tag ezstore.product.api khainx127/ezstore.product.api
docker push khainx127/ezstore.product.api

docker tag ezstore.warehouse.api khainx127/ezstore.warehouse.api
docker push khainx127/ezstore.warehouse.api
