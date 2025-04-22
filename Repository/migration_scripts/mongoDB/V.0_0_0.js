db.createUser({
    user: "Toan",
    pwd: "Tu",
    roles: [{ role: "readWrite", db: "mydatabase" }]
});

use("e-commerce");
db.createCollection("information_customers");
db.information_customers.insertOne(
    {
        "_id": "64f0c8e4f1d2e7d1f4a5b8c3",
        "Bio": "",
        "Email": "toantu03@gmail.com",
        "Name": "Toan Tu",
        "Password": "Toantv1234",
        "Phone": "0334677552",
        "Rank": "Thành Viên",
        "Role": "sellers",
        "Seller_profile": {
            "is_seller": true,
            "Name": "Shop Tra Vinh",
            "Address": "127A Bui Xuan Soan, Phuong 7 TP Tra Vinh",
            "Shipping_Method": "Bưu điện Việt Nam (Vietnam Post)",
            "Bank": "Vietcombank",
            "Account_number": "0336655411"
        },
            "created_at": {"$date": "2025-04-22T03:26:13.690Z"},
            "updated_at": {"$date": "2025-04-22T03:26:13.691Z"}
        }
);