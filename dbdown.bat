@echo off
echo "[STEP]: Stopping and removing containers..."
docker-compose down

echo "[STEP]: Clean up data from containers..."
IF EXIST "Repository\data_base_log" (
    rmdir /s /q "Repository\data_base_log"
)

echo "[STATUS]: Successfully removed containers and data."