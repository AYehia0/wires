#!/bin/bash
SECONDS=0

# kill the server
echo "Killing server"
sudo pkill backend

# check if the project exists if not clone it
if [ ! -d "$HOME/wires" ]; then
    echo "Cloning the repo"
    git clone https://github.com/AYehia0/wires.git
fi

cd $HOME/wires

# pull the latest code
echo "fetching latest changes from repo"
git pull

cd backend/

# build the server
echo "Publishing/Building the server"
dotnet publish 

# start the server
# nohup sudo ./backend &> /dev/null &
echo "Starting the server"
cd bin/Release/net8.0 && sudo ./backend &> /dev/null &

echo "Deployment completed in $(($SECONDS % 60)) seconds"
