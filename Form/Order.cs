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

            //label1.Text = cartItems.ToString();
            
            header.Text = "Đặt hàng";
            header.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            header.ForeColor = Color.White;
            header.BackColor = Color.DarkTurquoise;
            header.Width = this.Width;
            header.Height = 24;
            header.TextAlign = ContentAlignment.MiddleCenter;
            header.Location = new Point(0, 8);
            
            int stt = 1;

            //flowLayoutPanel1.Controls.Clear();  // Clear các control cũ trước khi load mới

            /*foreach (BsonDocument item in cartItems)
            {
                //Console.WriteLine(item.ToString());
                
                // Tạo panel cho từng dòng
                var itemPanel = new Panel();
                itemPanel.Width = flowLayoutPanel1.Width - 30;
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
                lblName.Text = item.GetValue("name").ToString();
                lblName.Width = 200;
                lblName.Location = new Point(30, 7);
                
                // Label tên sản phẩm
                var lblQuantity = new Label();
                lblQuantity.BackColor = Color.Transparent;
                lblQuantity.Text = item.GetValue("quantity").ToString();
                lblQuantity.Width = 200;
                lblQuantity.Location = new Point(flowLayoutPanel1.Width - 80, 7);
                
                // Label giá sản phẩm
                var lblPrice = new Label();
                lblPrice.BackColor = Color.Transparent;
                int itemPrice = item.GetValue("price").ToInt32();
                lblPrice.Text = totalPrice.ToString("N0") + "đ";
                lblPrice.Width = 200;
                lblPrice.Location = new Point(flowLayoutPanel1.Width - 50, 7);
                
                itemPanel.Controls.Add(lblStt);
                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(lblQuantity);
                itemPanel.Controls.Add(lblPrice);
                
                // Thêm vào flowLayoutPanelCart
                flowLayoutPanel1.Controls.Add(itemPanel);
            }*/
            
            //Giới hạn ký tự
            textBox2.MaxLength = 16;
            richTextBox1.MaxLength = 500;
            
            label5.Text = "Tổng cộng: " + totalPrice.ToString("N0") + " đ";
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            label2.Hide();
            textBox2.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            radioButton4.Hide();
            label3.Hide();
            label5.Hide();
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
        
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Vui lòng nhập địa chỉ")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userId);
            // Tìm document
            var customer = _customerCollection.Find(filter).FirstOrDefault();
            if (customer != null && customer.Contains("address"))
            {
                var address = customer["address"].ToString();
                textBox1.Text = address;
            }
            else
            {
                textBox1.Text = "Vui lòng nhập địa chỉ";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void Order_Load(object sender, EventArgs e)
        {
            
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
                label3.Show();
                textBox2.Show();
            } 
            else
            {
                label3.Hide();
                textBox2.Hide();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                paymentMethod = "E Wallet";
                label3.Show();
                textBox2.Show();
            } 
            else
            {
                label3.Hide();
                textBox2.Hide();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                paymentMethod = "installment payment";
                label3.Show();
                textBox2.Show();
            } 
            else
            {
                label3.Hide();
                textBox2.Hide();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            label1.Hide();
            textBox1.Hide();
            label4.Hide();
            richTextBox1.Hide();
            
            label2.Show();
            label5.Show();
            //label3.Show();
            //textBox2.Show();
            
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Show();
            radioButton4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        
        private void Button3_Click(object sender, EventArgs e)
        {
            // Action for button3 click
            MessageBox.Show("Button 3 was clicked!");
        }
        
        private void Button4_Click(object sender, EventArgs e)
        {
            label2.Hide();
            label5.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            radioButton4.Hide();
            //label3.Hide();
            //textBox2.Hide();

            
            label1.Show();
            textBox1.Show();
            label4.Show();
            richTextBox1.Show();
            
            button1.Show();
            button2.Show();
        }
    }
    
    
}