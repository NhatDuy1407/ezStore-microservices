docker-compose -f docker-compose-webui.yml build

docker tag ezstore.webui khainx127/ezstore.webui
docker push khainx127/ezstore.webui
