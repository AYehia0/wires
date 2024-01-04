#!/bin/bash

# execute the production_deploy.sh script on the server
sshcmd="ssh -t none@api.ayehia0.info"
$sshcmd screen -S "Deployment" /home/none/wires/production_deploy.sh
