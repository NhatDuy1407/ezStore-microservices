istioctl kube-inject -f k8s\k8s.service.api.yaml -o k8s\k8s.service.api.istio.yaml
kubectl apply -f k8s\k8s.service.api.istio.yaml

kubectl -n istio-system port-forward istio-egressgateway-56bdd5fcfb-rnwbc 30101
REM kubectl -n istio-system port-forward istio-egressgateway-56bdd5fcfb-rnwbc 30102
