REM Istio Dashboad
kubectl -n istio-system port-forward $(kubectl -n istio-system get pod -l app=grafana -o jsonpath='{.items[0].metadata.name}') 4001:3000 &
REM http://localhost:4001