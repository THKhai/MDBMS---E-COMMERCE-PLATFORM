using System;
using System.Windows.Forms;
using StackExchange.Redis;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    public partial class Cart : Form
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;
        private readonly IMongoCollection<BsonDocument> _customerCollection;
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDatabase;
        private string userEmail;
        
        public Cart()
        {
            InitializeComponent();
        }
        public Cart(string email)
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
                string name = product.GetValue("name", "").AsString;
                string category = product.GetValue("category", "").AsString;
                string price = product.GetValue("price", 0).ToString();

                // Lấy các thuộc tính sản phẩm
                BsonDocument attributes = product.GetValue("attributes", new BsonDocument()).AsBsonDocument;

                // Khởi tạo danh sách các cột (attribute) để điền vào DataGridView
                string size = attributes.Contains("size") ? attributes["size"].ToString() : "";
                string color = attributes.Contains("color") ? attributes["color"].ToString() : "";
                string brand = attributes.Contains("brand") ? attributes["brand"].ToString() : "";
                string material = attributes.Contains("material") ? attributes["material"].ToString() : "";
                string warranty = attributes.Contains("warranty") ? attributes["warranty"].ToString() : "";
                // string cpu = attributes.Contains("cpu") ? attributes["cpu"].ToString() : "";
                // string ram = attributes.Contains("ram") ? attributes["ram"].ToString() : "";
                // string storage = attributes.Contains("storage") ? attributes["storage"].ToString() : "";

                // Thêm dòng vào DataGridView với các cột attribute
                dgvProducts.Rows.Add(name, category, price, size, color, material, brand, warranty);
            }

            dgvProducts.ClearSelection();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("khoa beo 1");
            if (dgvProducts.CurrentRow != null)
            {
                Console.WriteLine("khoa beo 2");

                string name = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                int price = Convert.ToInt32(dgvProducts.CurrentRow.Cells[2].Value);
                int quantity = (int)nudQuantity.Value;
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
                        _redisDatabase.HashIncrement(cartKey, name, quantity);

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
