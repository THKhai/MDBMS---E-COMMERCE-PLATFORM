CREATE KEYSPACE IF NOT EXISTS mykeyspace WITH REPLICATION = { 'class': 'SimpleStrategy', 'replication_factor': 1 };

USE mykeyspace;

CREATE TABLE IF NOT EXISTS sample_table (
    id UUID PRIMARY KEY,
    name text
);

INSERT INTO sample_table (id, name) VALUES (uuid(), 'Sample Data 1');
INSERT INTO sample_table (id, name) VALUES (uuid(), 'Sample Data 2');
