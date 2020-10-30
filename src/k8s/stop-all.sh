#!/bin/bash
kubectl delete svc --all -n BWMS
kubectl delete deploy --all -n BWMS
kubectl delete virtualservice --all -n BWMS
kubectl delete destinationrule --all -n BWMS