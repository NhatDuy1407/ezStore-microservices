kubectl delete service microservice-identity-db
kubectl delete deployment microservice-identity-db

kubectl delete service microservice-services-queue
kubectl delete deployment microservice-services-queue

kubectl delete service microservice-services-db
kubectl delete deployment microservice-services-db

kubectl create -f .\k8s.service.db.yaml

kubectl get all