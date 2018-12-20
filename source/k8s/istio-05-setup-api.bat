istioctl kube-inject -f k8s\k8s.service.api.yaml -o k8s\k8s.service.api.istio.yaml
kubectl apply -f k8s\k8s.service.api.istio.yaml

kubectl -n istio-system port-forward istio-ingressgateway-7f4dd7d699-gf44v 30101
REM kubectl -n istio-system port-forward istio-ingressgateway-7f4dd7d699-gf44v 30102
