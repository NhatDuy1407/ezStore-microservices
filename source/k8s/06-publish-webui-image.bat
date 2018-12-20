docker-compose -f docker-compose-webui.yml build

docker tag ezstore.webui ezstoremicroservices/ezstore.webui
docker push ezstoremicroservices/ezstore.webui
