#!/bin/bash

# execute the production_deploy.sh script on the server
echo "Connecting to server..."
ssh none@api.ayehia0.info 'bash -s < /home/none/wires/production_deploy.sh'
