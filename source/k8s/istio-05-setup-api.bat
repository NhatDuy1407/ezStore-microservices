istioctl kube-inject -f k8s\k8s.service.api.yaml -o k8s\k8s.service.api.istio.yaml
kubectl apply -f k8s\k8s.service.api.istio.yaml

kubectl -n istio-system port-forward istio-ingressgateway-64cb7d5f6d-mntg6 30101
kubectl -n istio-system port-forward istio-ingressgateway-64cb7d5f6d-mntg6 30102
