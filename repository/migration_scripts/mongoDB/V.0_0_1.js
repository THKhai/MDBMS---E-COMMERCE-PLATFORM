use("e-commerce");

db.createCollection("products");
db.products.insertMany([
    {
        name: "Áo thun Nike",
        product_type: "fashion",
        category: "Thời trang",
        price: 250000,
        stock: 50,
        description: "Size L, màu đen, chất liệu cotton",
        seller_id: "64f0c8e4f1d2e7d1f4a5b8c3",
        sale: {
            percent: 10,
            start_date: new Date("2025-10-01"),
            end_date: new Date("2025-10-15")
        }
    },
    {
        name: "Quần short Adidas",
        product_type: "fashion",
        category: "Thời trang",
        price: 300000,
        stock: 35,
        description: "Size M, màu xám, chất liệu Polyester",
        seller_id: "6806779aae3f0d475efa13f0"
    },
    {
        name: "Giày Converse Classic",
        product_type: "fashion",
        category: "Giày dép",
        price: 900000,
        stock: 20,
        description: "Size 42, màu trắng, chất liệu Canvas",
        seller_id: "64f0c8e4f1d2e7d1f4a5b8c3"
    },
    {
        name: "Tai nghe Bluetooth Sony",
        product_type: "electronics",
        category: "Thiết bị điện tử",
        price: 1200000,
        stock: 15,
        description: "Thương hiệu Sony, bảo hành 12 tháng, kết nối Bluetooth 5.0",
        seller_id: "64f0c8e4f1d2e7d1f4a5b8c3"
    },
    {
        name: "Laptop Dell Inspiron",
        product_type: "electronics",
        category: "Máy tính",
        price: 15000000,
        stock: 10,
        description: "Thương hiệu Dell, bảo hành 24 tháng, CPU Intel i5, RAM 8GB",
        seller_id: "6806779aae3f0d475efa13f0"
    },
    {
        name: "Sách Clean Code",
        product_type: "book",
        category: "Sách",
        price: 200000,
        stock: 100,
        description: "Tác giả Robert C. Martin, 464 trang, ngôn ngữ Tiếng Việt",
        seller_id: "64f0c8e4f1d2e7d1f4a5b8c3"
    },
    {
        name: "Túi xách nữ LV",
        product_type: "fashion",
        category: "Phụ kiện",
        price: 4500000,
        stock: 5,
        description: "Chất liệu da thật, màu nâu, kích thước trung",
        seller_id: "6806779aae3f0d475efa13f0"
    },
    {
        name: "Nồi chiên không dầu Lock&Lock",
        product_type: "home_appliance",
        category: "Gia dụng",
        price: 2200000,
        stock: 8,
        description: "Thương hiệu Lock&Lock, dung tích 5L, công suất 1500W",
        seller_id: "6806779aae3f0d475efa13f0",
        sale: {
            percent: 20,
            start_date: new Date("2025-04-20"),
            end_date: new Date("2025-04-30")
        }
    },
    {
        name: "Điện thoại iPhone 13",
        product_type: "electronics",
        category: "Điện thoại",
        price: 20000000,
        stock: 12,
        description: "Thương hiệu Apple, dung lượng 128GB, màu Midnight",
        seller_id: "6806779aae3f0d475efa13f0"

    },
    {
        name: "Bình giữ nhiệt Tiger",
        product_type: "home_appliance",
        category: "Gia dụng",
        price: 650000,
        stock: 25,
        description: "Thương hiệu Tiger, dung tích 500ml, chất liệu Inox",
        seller_id: "6806779aae3f0d475efa13f0"

    }
]);