<#
  Скрипт выполняте сохранение схемы локальной базы данныйх MySQL в файл db-schema.sql
  Локальная база данных - это та которая прописана в user-secret проекта Seterator\Seterator.csproj
  в поле с названием "ConnectionStrings:Local".
  Так же в этом user-secrets должен быть прописан путь к локальной директории MySQL\bin,
  например 
  { ...
    "MysqlBinRoot": "D:\\MySQL Server\\bin" 
  }
#>


function Get-LocalConnectionString() {
    function Get-Value($name, $full) {
        if ($full -match "$name=(.*?);")
        { $matches[1] }
        else
        { $null }
    }
    dotnet user-secrets list --project ./Seterator/Seterator.csproj |
    Select-String -Pattern "^ConnectionStrings:(.*?) = (.*)$" -AllMatches |
    ForEach-Object {
        $connectionString = $_.Matches[0].Groups[2].Value
        $name = $_.Matches[0].Groups[1].Value
        [ PSCustomObject ] @{ 
            Full = $connectionString 
            Name = $name
            Server = Get-value "server" $connectionString
            UserID = Get-value "UserId" $connectionString
            Database = Get-value "database" $connectionString
            Password = Get-value "password" $connectionString
        }
    } |
    Where-Object -Prop Name -eq "Local"
}

function Get-MySqlRoot() {
    $configLineMatch = dotnet user-secrets list --project ./Seterator/Seterator.csproj |
    Select-String -Pattern "^MysqlBinRoot = (.*)$" | 
    Select-Object -First 1
    $configLineMatch.Matches[0].Groups[1].Value
}

$connection = Get-LocalConnectionString
$user = $connection.UserID
$password = $connection.Password
$database = $connection.Database
$mysqlRoot = Get-MySqlRoot
$mysqlDump = [IO.Path]::Combine($mysqlRoot, 'mysqldump')
iex "& '$mysqlDump' -u $user -p$password --skip-add-drop-table --skip-add-locks --skip-disable-keys --skip-set-charset --skip-comments --no-data $database" | Out-File db-schema.sql
