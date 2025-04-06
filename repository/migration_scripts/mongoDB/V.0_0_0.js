db.createUser({
    user: "Toan",
    pwd: "Tu",
    roles: [{ role: "readWrite", db: "mydatabase" }]
});

db = db.getSiblingDB("mydatabase");

db.sampleCollection.insertMany([
    { name: "Sample Data 1" },
    { name: "Sample Data 2" }
]);
