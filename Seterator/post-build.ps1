#! /usr/bin/pwsh
Write-Output "Post-build script starts"
npm install
npm run dev
