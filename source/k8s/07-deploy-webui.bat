kubectl delete service ezstore-webui
kubectl delete deployment ezstore-webui

kubectl apply -f k8s\k8s.webui.yaml

kubectl get all