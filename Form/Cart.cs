using System;
using System.Windows.Forms;
using StackExchange.Redis;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using System.Drawing;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    public partial class Cart : Form
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;
        private readonly IMongoCollection<BsonDocument> _customerCollection;
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDatabase;
        private string userEmail;
        private ObjectId userId;
        private string cartKey;
        
        public Cart()
        {
            InitializeComponent();
        }
        
        public Cart(string email)
        {
            InitializeComponent();

            userEmail = email;

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
                Console.WriteLine("Cart key: " + cartKey);
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

        private void Cart_Load(object sender, EventArgs e)
        {
            if (userId != ObjectId.Empty)
            {
                LoadCart();
            }

        }

        private void LoadCart()
        {
            /*var cartItems = _redisDatabase.HashGetAll(cartKey);

            if (cartItems.Length == 0)
            {
                MessageBox.Show("Giỏ hàng trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo DataTable
            DataTable table = new DataTable();
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));

            // Thêm từng item vào bảng
            foreach (var item in cartItems)
            {
                table.Rows.Add(item.Name, (int)item.Value);
            }

            // Gán DataTable vào DataGridView
            dataGridView1.DataSource = table;*/
            flowLayoutPanelCart.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelCart.WrapContents = false;
            flowLayoutPanelCart.AutoScroll = true;
            
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
                return;
            }

            flowLayoutPanelCart.Controls.Clear();  // Clear các control cũ trước khi load mới

            int stt = 1;
            foreach (var item in cartItems)
            {
                string productName = item.Name;
                int quantity = (int)item.Value;

                // Tạo panel cho từng dòng
                var itemPanel = new Panel();
                itemPanel.Width = flowLayoutPanelCart.Width - 30;
                itemPanel.Height = 30;
                itemPanel.Margin = new Padding(1);

                // Label số thứ tự
                var lblStt = new Label();
                lblStt.Text = stt.ToString();
                lblStt.Width = 40;
                lblStt.Location = new Point(10, 7);
                stt++;
                
                // Label tên sản phẩm
                var lblName = new Label();
                lblName.Text = productName;
                lblName.Width = 200;
                lblName.Location = new Point(60, 7);

                // NumericUpDown số lượng
                var nudQuantity = new NumericUpDown();
                nudQuantity.Value = quantity;
                nudQuantity.Minimum = 1;
                nudQuantity.Maximum = 100;
                nudQuantity.Width = 60;
                nudQuantity.Location = new Point(flowLayoutPanelCart.Width - 155, 7);
                nudQuantity.Tag = productName; // Gán tag để biết đang chỉnh sản phẩm nào
                nudQuantity.ValueChanged += NudQuantity_ValueChanged;

                // Nút xoá
                var btnDelete = new Button();
                btnDelete.Text = "Xoá";
                btnDelete.Width = 60;
                btnDelete.Location = new Point(flowLayoutPanelCart.Width - btnDelete.Width - 30, 7);
                btnDelete.Tag = productName;
                btnDelete.Click += BtnDelete_Click;

                // Thêm vào itemPanel
                itemPanel.Controls.Add(lblStt);
                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(nudQuantity);
                itemPanel.Controls.Add(btnDelete);

                // Thêm vào flowLayoutPanelCart
                flowLayoutPanelCart.Controls.Add(itemPanel);
            }
        }
        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            string productName = nud.Tag.ToString();
            int newQuantity = (int)nud.Value;

            _redisDatabase.HashSet(cartKey, productName, newQuantity);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string productName = btn.Tag.ToString();

            _redisDatabase.HashDelete(cartKey, productName);
            LoadCart();  // Refresh lại
        }

    }
}