kubectl delete service microservice-identity-server
kubectl delete deployment microservice-identity-server

kubectl delete service microservice-logging-api
kubectl delete deployment microservice-logging-api

kubectl delete service microservice-logging-background
kubectl delete deployment microservice-logging-background

kubectl delete service microservice-notification-background
kubectl delete deployment microservice-notification-background

kubectl create -f k8s\k8s.service.api.yaml

kubectl get all