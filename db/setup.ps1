# inputs
$reset = $args.Contains('-reset');

# defaults
$dbName = 'tracker_app'

# connection using environment variable
$env:PGPASSWORD = 'root'
$dbExists = $( psql -U postgres -h localhost -p 5432 -AXqtc "SELECT 1 FROM pg_database WHERE datname = '$( $dbName )';" )
if ($dbExists)
{
    if ($reset)
    {
        psql -U postgres -h localhost -p 5432 -c "DROP DATABASE $( $dbName )"
    }
    echo "Database $( $dbName ) already exists"
}
else
{
    psql -U postgres -h localhost -p 5432 -c "CREATE DATABASE $( $dbName )"
}
$env:PGPASSWORD = ''

# run liquibase update
liquibase update