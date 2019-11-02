echo "Deployment started."
sudo apt-get -y install sshpass
sshpass -e -v ssh -o StrictHostKeyChecking=no root@5.63.154.249 '
    echo "SSH session started.";
    cd seterator;
    systemctl stop seterator;
    echo "Service stopped."
    git pull;
    dotnet build;
    echo "Build completed."
    systemctl start seterator;
    echo "Service started.";
'
echo "Deployment complited."