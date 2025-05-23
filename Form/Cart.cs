using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;
using System.Collections.Generic;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class Cart : System.Windows.Forms.Form
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;
        private readonly IMongoCollection<BsonDocument> _customerCollection;
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDatabase;
        private string userEmail;
        private ObjectId userId;
        private string cartKey;


        private int totalPrice = 0;
        public Cart(string email)
        {
            InitializeComponent();
            // Ngăn resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            userEmail = email;  // Gán email từ form Home

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

        private BsonDocument  GetProduct(string productId, int quantity)
        {
            var objectId = ObjectId.Parse(productId);  // convert string to ObjectId
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            var product = _productCollection.Find(filter).FirstOrDefault();
            if (product != null)
            {
                product.Add("quantity", quantity); // Add quantity field to BsonDocument
            }
            return product;
        }
        
        private void UpdateTotalCartPrice()
        {
            var cartItems = _redisDatabase.HashGetAll(cartKey);

            int totalCartPrice = 0;

            foreach (var item in cartItems)
            {
                string productInfoJson = item.Value;
    
                // Chuyển chuỗi JSON về BsonDocument
                BsonDocument productInfo = BsonDocument.Parse(productInfoJson);

                // Lấy các trường từ BsonDocument
                string productId = item.Name;  // productId là field trong Hash
                string sellerId = productInfo["sellerId"].AsString;
                int quantity = productInfo["quantity"].AsInt32;

                BsonDocument itemInfo = GetProduct(productId, quantity);
                int price = itemInfo.GetValue("price", 0).ToInt32();

                totalCartPrice += price * quantity;
            }

            label1.Text = "Tổng cộng: " + totalCartPrice.ToString("N0") + "đ";
            totalPrice = totalCartPrice;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            if (userId != ObjectId.Empty)
            {
                LoadCart();
            }

        }

        private void LoadCart()
        {
            flowLayoutPanelCart.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelCart.WrapContents = false;
            flowLayoutPanelCart.AutoScroll = true;
            
            label2.Text = "Giỏ hàng";
            label2.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.BackColor = Color.DarkTurquoise;
            label2.Width = this.Width;
            label2.Height = 24;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Location = new Point(0, 8);
            
            int stt = 1;
            int totalCartPrice = 0; // Tổng giỏ hàng
            
            var cartItems = _redisDatabase.HashGetAll(cartKey);

            if (cartItems.Length == 0)
            {
                flowLayoutPanelCart.Controls.Clear();
                // Nếu giỏ hàng trống — hiển thị thông báo
                Label lblEmpty = new Label();
                lblEmpty.Text = "Giỏ hàng trống.";
                lblEmpty.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.AutoSize = true;
                lblEmpty.Margin = new Padding(20);

                flowLayoutPanelCart.Controls.Add(lblEmpty);
                label1.Text = "Tổng cộng: 0đ";
                totalPrice = 0;
                return;
            }

            flowLayoutPanelCart.Controls.Clear();  // Clear các control cũ trước khi load mới

            foreach (var item in cartItems)
            {
                string productInfoJson = item.Value;

                BsonDocument productInfo = BsonDocument.Parse(productInfoJson);

                // Lấy các trường từ BsonDocument
                string productId = item.Name;  // productId là field trong Hash
                string sellerId = productInfo["sellerId"].AsString;
                int quantity = productInfo["quantity"].AsInt32;

                BsonDocument itemInfo = GetProduct(productId, quantity);
                
                // Tạo panel cho từng dòng
                var itemPanel = new Panel();
                itemPanel.Width = flowLayoutPanelCart.Width - 30;
                itemPanel.Height = 30;
                itemPanel.Margin = new Padding(1);

                // Label số thứ tự
                var lblStt = new Label();
                lblStt.BackColor = Color.Transparent;
                lblStt.Text = stt.ToString();
                lblStt.Width = 20;
                lblStt.Location = new Point(10, 7);
                stt++;
                
                // Label tên sản phẩm
                var lblName = new Label();
                lblName.BackColor = Color.Transparent;
                lblName.Text = itemInfo.GetValue("name", "").AsString;
                lblName.Width = 200;
                lblName.Location = new Point(30, 7);

                // Nút xoá
                var btnDelete = new Button(); 
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.FlatAppearance.BorderColor = Color.Red; 
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.BackColor = Color.Red;
                btnDelete.ForeColor = Color.White;
                btnDelete.Text = "Xoá";
                btnDelete.Width = 60;
                btnDelete.Height = 20;
                btnDelete.Location = new Point(flowLayoutPanelCart.Width - 175, 2);
                btnDelete.Tag = productId;
                btnDelete.Click += BtnDelete_Click;

                // Label giá sản phẩm
                var lblPrice = new Label();
                lblPrice.BackColor = Color.Transparent;
                int price = itemInfo.GetValue("price", 0).ToInt32();
                totalPrice = price * quantity;
                lblPrice.Text = totalPrice.ToString("N0") + "đ";
                lblPrice.Width = 200;
                lblPrice.Location = new Point(flowLayoutPanelCart.Width - btnDelete.Width - 50, 7);

                // NumericUpDown số lượng
                var nudQuantity = new NumericUpDown();
                nudQuantity.Value = quantity;
                nudQuantity.Minimum = 1;
                nudQuantity.Maximum = 100;
                nudQuantity.Width = 60;
                nudQuantity.Location = new Point(flowLayoutPanelCart.Width - 240, 2);
                nudQuantity.Tag = new { ProductId = productId, Price = price, Label = lblPrice, TotalPrice = label1};
                nudQuantity.ValueChanged += NudQuantity_ValueChanged;
                
                totalCartPrice += totalPrice; // cộng dồn giá trị từng sản phẩm
                totalPrice = totalCartPrice;
                // Thêm vào itemPanel
                itemPanel.Controls.Add(lblStt);
                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(nudQuantity);
                itemPanel.Controls.Add(btnDelete);
                itemPanel.Controls.Add(lblPrice);

                // Thêm vào flowLayoutPanelCart
                flowLayoutPanelCart.Controls.Add(itemPanel);
            }
            label1.Text = "Tổng cộng: " + totalCartPrice.ToString("N0") + "đ";

        }
        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var info = (dynamic)nud.Tag;

            string productId = info.ProductId;
            int price = info.Price;
            Label lblPrice = info.Label;

            int newQuantity = (int)nud.Value;

            // Cập nhật lại Redis
            string cartItem = _redisDatabase.HashGet(cartKey, productId);

            var productInfo = BsonDocument.Parse(cartItem);

            // Cập nhật lại số lượng
            productInfo["quantity"] = newQuantity;

            Console.WriteLine(productInfo.ToString());
            // Lưu lại vào Redis
            _redisDatabase.HashSet(cartKey, productId, productInfo.ToString());
            
            
            // Cập nhật lại giá hiển thị
            int newTotalPrice = price * newQuantity;
            lblPrice.Text = newTotalPrice.ToString("N0") + "đ";
            
            totalPrice = newTotalPrice;
            // Cập nhật lại tổng giá giỏ hàng
            UpdateTotalCartPrice();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string productName = btn.Tag.ToString();

            _redisDatabase.HashDelete(cartKey, productName);
            LoadCart();  // Refresh lại
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (totalPrice == 0)
            {
                MessageBox.Show("Giỏ hàng của bạn đang trống. Vui lòng thêm sản phẩm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại và không mở form Order
            }
            
            Order order = new Order(userEmail, totalPrice);
            order.FormClosed += delegate
            {
                LoadCart();
            };
            order.ShowDialog(); // Dùng ShowDialog để mở form giỏ hàng như một modal dialog
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}