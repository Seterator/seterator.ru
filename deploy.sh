echo "[*] Deployment started..."
sshpass -e ssh -o StrictHostKeyChecking=no root@45.151.144.11 '
    echo "[*] SSH session started..."                                   &&
    cd /var/seterator                                                   &&
    echo "[*] Stopping seterator.service..."                            &&
    systemctl stop seterator                                            &&
    echo "[*] seterator.service stopped, updating source code..."       &&
    git pull                                                            &&
    echo "[*] Source code updated, building..."                         &&
    dotnet build                                                        &&
    echo "[*] Build completed, applying migration..."                   &&
    dotnet ef database update --project ./Seterator/Seterator.csproj    &&
    echo "[*] Migration applied"
    echo "[*] starting seterator.service..."
    systemctl start seterator                                           &&
    echo "[*] seterator.service started"
'
echo "[*] Deployment complited!"
