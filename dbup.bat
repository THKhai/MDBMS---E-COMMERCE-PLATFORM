@echo off


cd .

echo "[STEP]: Starting Docker containers..."
docker-compose up -d
if %errorlevel% neq 0 (
    echo "[ERR]:Error starting Docker containers. Exiting script."
    exit /b %errorlevel%
)

@echo off
setlocal enabledelayedexpansion

echo [STATUS]: Waiting to establish connections to all containers...
set MAX_ATTEMPTS=40
set INTERVAL=10

for /L %%i in (1,1,%MAX_ATTEMPTS%) do (
    set "all_ready=true"

    REM Check Redis connection
    docker exec -i redis_container redis-cli ping >nul 2>&1
    if !errorlevel! neq 0 (
        echo [STATUS]: Wait for Redis connection to be ready.
        set "all_ready=false"
    )

    REM Check MongoDB connection
    docker exec -i mongo_container /usr/bin/mongosh --eval "db.runCommand({ping:1})" >nul 2>&1
    if !errorlevel! neq 0 (
        echo [STATUS]: Wait For MongoDB connection to be ready.
        set "all_ready=false"
    )

    REM Check Cassandra connection
    docker exec -i cassandra_container cqlsh -e "DESCRIBE keyspaces;" >nul 2>&1
    if !errorlevel! neq 0 (
        echo [STATUS]: Wait for Cassandra connection to be ready.
        set "all_ready=false"
    )

    REM Check Neo4j connection
    docker exec -i neo4j_container cypher-shell -u neo4j -p superadmin "RETURN 1" >nul 2>&1
    if !errorlevel! neq 0 (
        echo [STATUS]: Wait for Neo4j connection to be ready.
        set "all_ready=false"
    )

    REM Exit loop if all connections are ready
    if "!all_ready!"=="true" (
        echo [STATUS]: Connections to all containers established successfully!
        goto all_connections_ready
    )

    echo [STATUS]: Retrying in %INTERVAL% seconds...
    timeout /t %INTERVAL% >nul
)

echo [ERR]: Unable to establish connections to all containers after %MAX_ATTEMPTS% time.
exit /b 1

:all_connections_ready
echo "[STATUS]: All containers are ready."
echo "[STEP]: Migration data base..."
echo "[STATUS]: Copying migration scripts for Cassandra container..."
docker cp ".\Repository\migration_scripts\cassandra" cassandra_container:/var/lib/
if %errorlevel% neq 0 (
    echo "[ERR]: Failed to copy migration scripts to Cassandra container."
    exit /b %errorlevel%
)

echo "[STATUS]: Initializing Cassandra with all .cql scripts..."
for %%f in (.\Repository\migration_scripts\cassandra\*.cql) do (
    echo Running %%~nxf...
    docker cp "%%f" cassandra_container:/var/lib/cassandra/%%~nxf
    docker exec -i cassandra_container cqlsh -f /var/lib/cassandra/%%~nxf
    if %errorlevel% neq 0 (
        echo "[ERR]: Failed to execute %%~nxf. Continuing with the next file..."
        exit /b %errorlevel%
    )
)
echo "[STATUS]: Cassandra has been initialized successfully with data!"

echo "[STATUS]: Copying migration scripts for mongoDB container..."
docker cp ".\Repository\migration_scripts\mongoDB" mongo_container:/scripts/
if %errorlevel% neq 0 (
    echo "[ERR]: Failed to copy migration scripts to MongoDB container."
    exit /b %errorlevel%
)

echo "[STATUS]: Executing all .js scripts inside MongoDB container..."
for %%f in (.\Repository\migration_scripts\mongoDB\*.js) do (
    echo Running %%~nxf...
    docker exec -i mongo_container /usr/bin/mongosh /scripts/%%~nxf
    if %errorlevel% neq 0 (
        echo "[ERR]: Failed to execute %%~nxf inside MongoDB. Continuing with the next file..."
    )
)
echo "[STATUS]: MongoDB has been initialized successfully with JavaScript scripts!"

echo "[STATUS]: Initializing Neo4j with data..."
docker cp ".\Repository\migration_scripts\neo4j" neo4j_container:/var/lib/
if %errorlevel% neq 0 (
    echo "[ERR]: Failed to copy migration scripts to Neo4j container."
    exit /b %errorlevel%
)

for %%f in (.\Repository\migration_scripts\neo4j\*.cypher) do (
    echo Executing %%~nxf...
    docker exec -i neo4j_container cypher-shell -u neo4j -p superadmin -f /var/lib/neo4j/%%~nxf
    if %errorlevel% neq 0 (
        echo "[ERR]: Failed to execute %%~nxf in Neo4j. Continuing with the next file..."
    )
)
echo "[STATUS]: Neo4j has been initialized successfully with data!"


echo "[STATUS]: Initializing Redis with data..."
docker cp ".\Repository\migration_scripts\redis" redis_container:/data/
if %errorlevel% neq 0 (
    echo "[ERR]: Failed to copy migration scripts to Redis container."
    exit /b %errorlevel%
)

for %%f in (.\Repository\migration_scripts\redis\*.rdb) do (
    echo Restoring %%~nxf...
    docker exec -i redis_container sh -c "cat /data/redis/%%~nxf | redis-cli --pipe"
    if %errorlevel% neq 0 (
        echo "[ERR]: Failed to restore %%~nxf into Redis. Continuing with the next file..."
    )
)
echo "[STATUS]: Redis has been initialized successfully with data!"

echo "[STATUS]: All services have been initialized successfully!"

