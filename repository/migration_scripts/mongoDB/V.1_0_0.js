use("e-commerce");

db.createCollection("products");


db.products.insertMany([
    {
        name: "Áo thun Nike",
        product_type: "fashion",
        category: "Thời trang",
        price: 250000,
        stock: 50,
        attributes: {
            size: "L",
            color: "Đen",
            material: "Cotton"
        }
    },
    {
        name: "Quần short Adidas",
        product_type: "fashion",
        category: "Thời trang",
        price: 300000,
        stock: 35,
        attributes: {
            size: "M",
            color: "Xám",
            material: "Polyester"
        }
    },
    {
        name: "Giày Converse Classic",
        product_type: "fashion",
        category: "Giày dép",
        price: 900000,
        stock: 20,
        attributes: {
            size: 42,
            color: "Trắng",
            material: "Canvas"
        }
    },
    {
        name: "Tai nghe Bluetooth Sony",
        product_type: "electronics",
        category: "Thiết bị điện tử",
        price: 1200000,
        stock: 15,
        attributes: {
            brand: "Sony",
            warranty: "12 tháng",
            connectivity: "Bluetooth 5.0"
        }
    },
    {
        name: "Laptop Dell Inspiron",
        product_type: "electronics",
        category: "Máy tính",
        price: 15000000,
        stock: 10,
        attributes: {
            brand: "Dell",
            warranty: "24 tháng",
            cpu: "Intel i5",
            ram: "8GB"
        }
    },
    {
        name: "Sách Clean Code",
        product_type: "book",
        category: "Sách",
        price: 200000,
        stock: 100,
        attributes: {
            author: "Robert C. Martin",
            pages: 464,
            language: "Tiếng Việt"
        }
    },
    {
        name: "Túi xách nữ LV",
        product_type: "fashion",
        category: "Phụ kiện",
        price: 4500000,
        stock: 5,
        attributes: {
            material: "Da thật",
            color: "Nâu",
            size: "Trung"
        }
    },
    {
        name: "Nồi chiên không dầu Lock&Lock",
        product_type: "home_appliance",
        category: "Gia dụng",
        price: 2200000,
        stock: 8,
        attributes: {
            brand: "Lock&Lock",
            capacity: "5L",
            power: "1500W"
        }
    },
    {
        name: "Điện thoại iPhone 13",
        product_type: "electronics",
        category: "Điện thoại",
        price: 20000000,
        stock: 12,
        attributes: {
            brand: "Apple",
            storage: "128GB",
            color: "Midnight"
        }
    },
    {
        name: "Bình giữ nhiệt Tiger",
        product_type: "home_appliance",
        category: "Gia dụng",
        price: 650000,
        stock: 25,
        attributes: {
            brand: "Tiger",
            capacity: "500ml",
            material: "Inox"
        }
    }
]);
