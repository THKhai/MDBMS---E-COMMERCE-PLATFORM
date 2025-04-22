using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class Order : System.Windows.Forms.Form
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;
        private readonly IMongoCollection<BsonDocument> _customerCollection;
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDatabase;
        private string userEmail;
        private ObjectId userId;
        private string cartKey;
        private BsonDocument cartItems;
        private int totalPrice;
        
        public Order(string email, BsonDocument items, int price)
        {
            InitializeComponent();
            
            // Ngăn resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            userEmail = email;  // Gán email từ form Home
            cartItems = items;
            totalPrice = price;
            
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("e-commerce");
            _productCollection = db.GetCollection<BsonDocument>("products");
            _customerCollection = db.GetCollection<BsonDocument>("information_customers");
            _redisConnection = ConnectionMultiplexer.Connect("localhost:6379"); // Nếu Redis trong Docker, thay localhost bằng IP của Redis container nếu cần
            _redisDatabase = _redisConnection.GetDatabase();
            
            userId = GetUserIdByEmail(userEmail);
            
            if (userId != ObjectId.Empty)
            {
                cartKey = "cart:" + userId.ToString();
                Console.WriteLine(@"Cart key: " + cartKey);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            label1.Text = totalPrice.ToString();
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
    }
}