use("e-commerce");
db.information_customers.insertMany([
    {
        "_id": ObjectId("64f0c8e4f1d2e7d1f4a5b8c9"),
        "Bio": "Gadget lover",
        "Email": "emma.gadget@gmail.com",
        "Name": "Emma Gadget",
        "Password": "Emma1234",
        "Phone": "0345566778",
        "Rank": "Thành Viên",
        "Role": "sellers",
        "Seller_profile": {
            "is_seller": true,
            "Name": "Emma's Electronics",
            "Address": "12 Tech Street, Silicon Valley",
            "Shipping_Method": "DHL",
            "Bank": "TechBank",
            "Account_number": "1122334455"
        },
        "created_at": {"$date": "2025-04-23T15:00:00.000Z"},
        "updated_at": {"$date": "2025-04-23T15:00:00.000Z"}
    },
    {
        "_id": ObjectId("64f0c8e4f1d2e7d1f4a5b8ca"),
        "Bio": "Fashion designer",
        "Email": "sophia.style@gmail.com",
        "Name": "Sophia Style",
        "Password": "Sophia1234",
        "Phone": "0356677889",
        "Rank": "Thành Viên",
        "Role": "sellers",
        "Seller_profile": {
            "is_seller": true,
            "Name": "Sophia's Styles",
            "Address": "34 Fashion Avenue, New York",
            "Shipping_Method": "FedEx",
            "Bank": "StyleBank",
            "Account_number": "2233445566"
        },
        "created_at": {"$date": "2025-04-23T16:00:00.000Z"},
        "updated_at": {"$date": "2025-04-23T16:00:00.000Z"}
    },
    {
        "_id": ObjectId("64f0c8e4f1d2e7d1f4a5b8cb"),
        "Bio": "Bookstore owner",
        "Email": "oliver.books@gmail.com",
        "Name": "Oliver Books",
        "Password": "Oliver1234",
        "Phone": "0367788990",
        "Rank": "Thành Viên",
        "Role": "sellers",
        "Seller_profile": {
            "is_seller": true,
            "Name": "Oliver's Bookstore",
            "Address": "56 Library Lane, Booktown",
            "Shipping_Method": "UPS",
            "Bank": "BookBank",
            "Account_number": "3344556677"
        },
        "created_at": {"$date": "2025-04-23T17:00:00.000Z"},
        "updated_at": {"$date": "2025-04-23T17:00:00.000Z"}
    },
    {
        "_id": ObjectId("64f0c8e4f1d2e7d1f4a5b8cc"),
        "Bio": "Home decor expert",
        "Email": "mia.decor@gmail.com",
        "Name": "Mia Decor",
        "Password": "Mia1234",
        "Phone": "0378899001",
        "Rank": "Thành Viên",
        "Role": "sellers",
        "Seller_profile": {
            "is_seller": true,
            "Name": "Mia's Home Decor",
            "Address": "78 Cozy Street, Homedale",
            "Shipping_Method": "Bưu điện Việt Nam (Vietnam Post)",
            "Bank": "DecorBank",
            "Account_number": "4455667788"
        },
        "created_at": {"$date": "2025-04-23T18:00:00.000Z"},
        "updated_at": {"$date": "2025-04-23T18:00:00.000Z"}
    },
    {
        "_id": ObjectId("64f0c8e4f1d2e7d1f4a5b8cd"),
        "Bio": "Outdoor gear specialist",
        "Email": "jack.outdoor@gmail.com",
        "Name": "Jack Outdoor",
        "Password": "Jack1234",
        "Phone": "0389900112",
        "Rank": "Thành Viên",
        "Role": "sellers",
        "Seller_profile": {
            "is_seller": true,
            "Name": "Jack's Outdoor Gear",
            "Address": "90 Adventure Road, Campville",
            "Shipping_Method": "DHL",
            "Bank": "OutdoorBank",
            "Account_number": "5566778899"
        },
        "created_at": {"$date": "2025-04-23T19:00:00.000Z"},
        "updated_at": {"$date": "2025-04-23T19:00:00.000Z"}
    }
]);