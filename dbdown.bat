echo "[STEP]: Stopping and removing containers..."
docker-compose down

echo "[STEP]: Clean up data from containers..."
IF EXIST "repository\data_base_log" (
    rmdir /s /q "repository\data_base_log"
)
