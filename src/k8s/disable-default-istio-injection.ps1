# In order to use the istio-injection annotation only on specific deployments within 
# the BWMS namespace, we need to disable automatic injection and enable it explicitly 
# on the namespace (see start-all script).

$config = kubectl get cm istio-sidecar-injector -o yaml -n istio-system
$config = $config -replace 'policy: enabled$', 'policy: disabled'
$config | kubectl apply -f -