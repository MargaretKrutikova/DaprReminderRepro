#!/bin/bash

PLACEMENT_PORT=$(docker inspect dapr_placement | grep HostPort | sort | uniq | grep -Eo '[0-9]*')

if [ -z "$PLACEMENT_PORT" ]; then
    PLACEMENT_PORT=50005
fi

echo "Connecting to Dapr placement service on port $PLACEMENT_PORT"

dapr run --components-path ./dapr/components --app-id reminder-test-app --app-port 5011 --dapr-http-port 3501 --dapr-grpc-port 54600
wait
