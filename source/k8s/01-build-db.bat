docker-compose -f docker-compose.init.yml build 

docker tag microservices.services.queue khainx127/microservices.services.queue
docker push khainx127/microservices.services.queue

docker tag microservices.identity.db khainx127/microservices.identity.db
docker push khainx127/microservices.identity.db

docker tag microservices.services.db khainx127/microservices.services.db
docker push khainx127/microservices.services.db

docker tag ezstore.product.db khainx127/ezstore.product.db
docker push khainx127/ezstore.product.db