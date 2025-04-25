using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class Product : System.Windows.Forms.Form
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;
        private readonly IMongoCollection<BsonDocument> _customerCollection;
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDatabase;
        private string userEmail;
        
        public Product()
        {
            InitializeComponent();
        }
        public Product(string email)
        {
            InitializeComponent();
            userEmail = email;  // Gán email từ form Home
            Console.WriteLine("Email passed to Cart 2: " + userEmail);
            // Ngăn resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Kết nối MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("e-commerce");
            _productCollection = db.GetCollection<BsonDocument>("products");
            _customerCollection = db.GetCollection<BsonDocument>("information_customers");
            _redisConnection = ConnectionMultiplexer.Connect("localhost:6379"); // Nếu Redis trong Docker, thay localhost bằng IP của Redis container nếu cần
            _redisDatabase = _redisConnection.GetDatabase();
            var product = _productCollection.Find(new BsonDocument()).FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine($"Product found: {product["name"]}"); // Kiểm tra xem sản phẩm có tồn tại không
            }
            else
            {
                Console.WriteLine("No product found.");
            }
        }
        private ObjectId GetUserIdByEmail(string email)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            var user = _customerCollection.Find(filter).FirstOrDefault();
            if (user != null)
            {
                return user["_id"].AsObjectId; // Trả về ObjectId của người dùng
            }

            return ObjectId.Empty; // Nếu không tìm thấy người dùng
        }
        
        private void FormAddToCart_Load(object sender, EventArgs e)
        {
            LoadProductList();
            nudQuantity.Value = 1;
        }

        private void LoadProductList()
        {
            dgvProducts.Rows.Clear();
            var products = _productCollection.Find(new BsonDocument()).ToList();
            // Duyệt qua tất cả sản phẩm và thêm vào DataGridView
            foreach (var product in products)
            {
                // Lấy các thông tin cơ bản của sản phẩm
                string id = product.GetValue("_id", "").ToString();
                //Console.WriteLine(id);

                string name = product.GetValue("name", "").AsString;
                string category = product.GetValue("category", "").AsString;
                int price = product.GetValue("price", 0).ToInt32();
                string stock = product.GetValue("stock", 0).ToString();
                string description = product.GetValue("description", "").ToString();
                // Lấy các thuộc tính sản phẩm
                string sellerID = product.GetValue("seller_id", "").ToString();
                BsonDocument sale = product.GetValue("sale", new BsonDocument()).AsBsonDocument;
                decimal salePercent = sale.Contains("percent") ? sale["percent"].ToDecimal() : 0;
                DateTime saleStartDate = sale.Contains("start_date") ? sale["start_date"].ToUniversalTime() : DateTime.MinValue;
                DateTime saleEndDate = sale.Contains("end_date") ? sale["end_date"].ToUniversalTime() : DateTime.MaxValue;
                // Kiểm tra xem giảm giá còn hiệu lực hay không
                string sellerId = product.GetValue("seller_id", "").ToString();
                
                var sellerFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(sellerId));
                var seller = _customerCollection.Find(sellerFilter).FirstOrDefault();
                string sellerName = seller != null ? seller["Seller_profile"]["Name"].ToString() : "Không xác định";
                
                decimal finalPrice = price; // Nếu không có sale, giá giữ nguyên
                if (salePercent > 0 && DateTime.UtcNow >= saleStartDate && DateTime.UtcNow <= saleEndDate)
                {
                    finalPrice = price - (price * salePercent / 100); // Tính giá sau giảm
                }

                // Hiển thị các thông tin vào DataGridView
                dgvProducts.Rows.Add(id, name, category, finalPrice, stock, description, salePercent, saleStartDate.ToString(), saleEndDate.ToString(), sellerName, sellerID);
            }

            dgvProducts.ClearSelection();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("khoa beo 1");
            if (dgvProducts.CurrentRow != null)
            {
                Console.WriteLine("khoa beo 2");

                string id = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                string name = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                int price = Convert.ToInt32(dgvProducts.CurrentRow.Cells[3].Value);
                int quantity = (int)nudQuantity.Value;
                string sellerID = dgvProducts.CurrentRow.Cells[10].Value.ToString();
                Console.WriteLine(sellerID);
                Console.WriteLine("khoa beo 3");

                // Lấy email người dùng từ session (hoặc biến toàn cục)
                string email = userEmail;

                Console.WriteLine(email);
                Console.WriteLine("khoa beo 4");

                if (!string.IsNullOrEmpty(email))
                {
                    // Lấy _id người dùng từ MongoDB
                    ObjectId userId = GetUserIdByEmail(email);

                    if (userId != ObjectId.Empty)
                    {
                        // Lưu giỏ hàng vào Redis với key = "cart:{userId}"
                        var cartKey = "cart:" + userId.ToString();

                        // Thêm sản phẩm vào giỏ hàng trong Redis
                        var productInfo = new BsonDocument
                        {
                            { "sellerId", sellerID },
                            { "quantity", quantity }
                        };
                        _redisDatabase.HashSet(cartKey, id, productInfo.ToString());

                        MessageBox.Show($"Đã thêm: {name} x{quantity} = {price * quantity:N0}đ", 
                            "Thêm vào giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Người dùng chưa đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
