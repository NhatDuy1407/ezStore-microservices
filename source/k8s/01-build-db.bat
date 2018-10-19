docker-compose -f docker-compose.init.yml build 

docker tag microservice.services.queue khainx127/microservice.services.queue
docker push khainx127/microservice.services.queue

docker tag microservice.identity.db khainx127/microservice.identity.db
docker push khainx127/microservice.identity.db

docker tag microservice.services.db khainx127/microservice.services.db
docker push khainx127/microservice.services.db

docker tag ezstore.product.db khainx127/ezstore.product.db
docker push khainx127/ezstore.product.db