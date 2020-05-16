echo "Deployment started."
sshpass -e ssh -o StrictHostKeyChecking=no root@5.63.154.249 '
    echo "[*] SSH session started...";
    cd seterator;
    systemctl stop seterator;
    echo "[*] seterator.service stopped...";
    git pull;
    echo "[*] Source code updated, building...";
    dotnet build;
    echo "[*] Build completed, applying migration..."
    dotnet --project ./Seterator/Seterator.csproj ef database update;
    echo "[*] Migration completed, starting seterator.service..."
    systemctl start seterator;
    echo "[*] seterator.service started...";
'
echo "[*] Deployment complited"
