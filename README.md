# MDBMS---E-COMMERCE-PLATFORM

## Overview
MDBMS (Multi-Database Management System) is an e-commerce platform that integrates multiple database systems, including Cassandra, MongoDB, Neo4j, and Redis. The platform is designed to demonstrate the use of various database technologies in a unified application.

## Features
- **Cassandra**: Used for managing structured data with high availability and scalability.
- **MongoDB**: Used for managing document-based data.
- **Neo4j**: Used for managing graph-based data.
- **Redis**: Used for caching and key-value data storage.

## Project Structure
- `InitForm.cs`: The main form for the Windows Forms application.
- `Program.cs`: The entry point of the application.
- `dbup.bat`: A script to start Docker containers, initialize databases, and run migration scripts.
- `dbdown.bat`: A script to stop and clean up Docker containers and data.
- `repository/migration_scripts/`: Contains migration scripts for each database:
    - `cassandra/`: `.cql` scripts for Cassandra.
    - `mongoDB/`: `.js` scripts for MongoDB.
    - `neo4j/`: `.cypher` scripts for Neo4j.
    - `redis/`: `.rdb` files for Redis.

## Prerequisites
- Docker and Docker Compose installed on your system.
- .NET Framework for running the Windows Forms application.

## Setup and Usage

### Step 1: Start the Databases
Run the `dbup.bat` script to start the Docker containers and initialize the databases:
```bash
  dbup.bat
```
### Step 2: Run the Application
1. Open the project in your IDE (e.g., JetBrains Rider).
2. Build the solution to ensure all dependencies are resolved.
3. Run the `Program.cs` file to start the Windows Forms application.

### Step 3: Stop and Clean Up
To stop the containers and clean up the data, run the `dbdown.bat` script:
```bash
  dbdown.bat
```

## Database Initialization Details

### Cassandra
- **Keyspace**: `mykeyspace`
- **Table**: `sample_table`
- **Sample Data**:
    - `Sample Data 1`
    - `Sample Data 2`
- **Initialization Script**: `repository/migration_scripts/cassandra/V.0_0_0.cql`

### MongoDB
- **Database**: `mydatabase`
- **Collection**: `sampleCollection`
- **User**: `Toan` with read/write access.
- **Sample Data**:
    - `Sample Data 1`
    - `Sample Data 2`
- **Initialization Script**: `repository/migration_scripts/mongoDB/V.0_0_0.js`

### Neo4j
- **Nodes**: `Student`
- **Sample Data**:
    - `Nguyễn Văn A`, `Trần Thị B`, `Lê Văn C`, `Phạm Thị D`, `Vũ Minh E`, `Vũ Thị F`, `Lê Văn G`, `Trần Thị H`
- **Initialization Script**: `repository/migration_scripts/neo4j/V.0_0_0.cypher`

### Redis
- **Key**: `user:1000`
- **Value**: `"Toan Tu"`
- **Initialization Script**: `repository/migration_scripts/redis/V.0_0_0.rdb`

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Author
- Toàn Từ
- Trần Hoàng Khải
- Bùi Chí Khang
- Lý Đăng Khoa

