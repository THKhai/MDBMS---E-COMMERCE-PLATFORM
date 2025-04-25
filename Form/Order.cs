using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;
using System.Collections.Generic;

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
        private string paymentMethod;

        private int totalPrice;
        
        public Order(string email, int price)
        {
            InitializeComponent();
            
            // Ngăn resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            userEmail = email;  // Gán email từ form Home
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
            
            header.Text = "Đặt hàng";
            header.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            header.ForeColor = Color.White;
            header.BackColor = Color.DarkTurquoise;
            header.Width = this.Width;
            header.Height = 24;
            header.TextAlign = ContentAlignment.MiddleCenter;
            header.Location = new Point(0, 8);
            
            //Ràng buộc Input
            textBox2.KeyPress += textBox2_KeyPress;
            textBox4.KeyPress += textBox4_KeyPress;
            textBox2.MaxLength = 16;
            textBox4.MaxLength = 11;
            richTextBox1.MaxLength = 500;
            
            panel1.Location = new Point(71, 115);
            panel2.Location = new Point(71, 108);
            panel3.Location = new Point(71, 142);
            
            label5.Text = "Tổng cộng: " + totalPrice.ToString("N0") + "đ";
            textBox3.Text = GetCustomerFieldById(userId, "Name");
            textBox4.Text = GetCustomerFieldById(userId, "Phone");
            textBox1.Text = GetCustomerFieldById(userId, "Address");

            label5.Hide();
            panel2.Hide();
            panel3.Hide();
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
        
        public string GetCustomerFieldById(ObjectId userId, string fieldName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userId);
            var customer = _customerCollection.Find(filter).FirstOrDefault();

            if (customer != null && customer.Contains(fieldName))
            {
                return customer[fieldName].ToString();
            }

            return null;
        }
        
        
        private void Order_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu không phải là số và không phải phím Backspace thì chặn
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu không phải là số và không phải phím Backspace thì chặn
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                paymentMethod = "COD";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                paymentMethod = "Credit Card";
                panel3.Show();
            } 
            else
            {
                panel3.Hide();
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi tiếp tục.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            button1.Hide();
            button2.Hide();

            var button3 = new Button();
            button3.Size = button1.Size;
            button3.Location = button1.Location;
            button3.Text = "Đặt hàng";
            button3.Click += new EventHandler(Button3_Click);
            this.Controls.Add(button3);
            
            var button4 = new Button();
            button4.Size = button2.Size;
            button4.Location = button2.Location;
            button4.Text = "Quay về";
            button4.Click += new EventHandler(Button4_Click);
            this.Controls.Add(button4);
            
            panel1.Hide();
            panel2.Show();
            
            label5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        
        private void Button3_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán trước khi tiếp tục.", "Thiếu phương thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Nếu không chọn, dừng lại và không thực hiện tiếp
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng điền số thẻ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            List<BsonDocument> orderItems = new List<BsonDocument>();

            var cartItems = _redisDatabase.HashGetAll(cartKey);

            foreach (var item in cartItems)
            {
                string productInfoJson = item.Value;
    
                // Chuyển chuỗi JSON về BsonDocument
                BsonDocument productInfo = BsonDocument.Parse(productInfoJson);

                // Lấy các trường từ BsonDocument
                string productId = item.Name;  // productId là field trong Hash
                string sellerId = productInfo["sellerId"].AsString;
                int quantity = productInfo["quantity"].AsInt32;
                
                var orderItemDocument = new BsonDocument
                {
                    { "ProductID", productId },
                    { "SellerID", sellerId },
                    { "Quantity", quantity }
                };
    
                Console.WriteLine($"Seller ID: {sellerId}, Quantity: {quantity}");

                // Thêm vào danh sách orderItems
                orderItems.Add(orderItemDocument);
            }
            var orderDocument = new BsonDocument
            {
                { "CustomerID", userId },
                { "OrderItems", new BsonArray(orderItems) },
                { "TotalPrice", totalPrice },
                { "Address", textBox1.Text },
                { "Note", richTextBox1.Text },
                { "PaymentMethod", paymentMethod },
                { "Status", "Pending" },
                { "created_at", DateTime.UtcNow },
                { "updated_at", DateTime.UtcNow }
            };
            
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("e-commerce");
            var collection = database.GetCollection<BsonDocument>("orders");
            
            collection.InsertOne(orderDocument);

            _redisDatabase.KeyDelete(cartKey);

            // Action for button3 click
            MessageBox.Show("Thanh toán thành công!");
            
            this.Hide();
            this.Close();
        }
        
        private void Button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
            
            button1.Show();
            button2.Show();
            label5.Hide();
        }
    }
    
    
}