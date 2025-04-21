using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class sign_up_seller : System.Windows.Forms.Form
    {
        public static string Key { get; set; }
        
        public sign_up_seller(string key)
        {
            InitializeComponent();
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
            // Set the session key
            Key = key;
            SetupComboBox();
        }
        
        private void SetupComboBox()
        {
            // Thiết lập các giá trị cho ComboBox
            comboBox1.Items.Add("Giao Hàng Nhanh");
            comboBox1.Items.Add("Bưu điện Việt Nam (Vietnam Post)");
            comboBox1.Items.Add("Giao Hàng Tiết Kiệm");
            comboBox1.Items.Add("Viettel Post");
            comboBox1.Items.Add("J&T Express");
            comboBox1.Items.Add("Ninja Van");
            comboBox1.Items.Add("Kerry Express");
            comboBox1.Items.Add("Shipchung");
        }
        private string Get_email()
        {
            string[] parts = Key.Split(':');
            
            if (parts.Length > 2)
            {
                string email = parts[2];
                return email;
            }
            else
            {
                MessageBox.Show("Invalid session key format.");
            }
            return "";
        }
        private void sign_up_seller_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");
                var filter = Builders<BsonDocument>.Filter.Eq("Email", Get_email());
                
                var seller_profile = new BsonDocument
                {
                    { "is_seller", true },
                    { "Name", textBox1.Text },
                    { "Address", textBox2.Text },
                    { "Shipping_Method", comboBox1.SelectedItem.ToString() },
                    { "Bank", textBox4.Text },
                    { "Account_number", textBox3.Text }
                }; 
                var update = Builders<BsonDocument>.Update.Combine(
                    Builders<BsonDocument>.Update.Set("Seller_profile", seller_profile),
                                Builders<BsonDocument>.Update.Set("Role", "sellers")
                    
                    );
                var result = collection.UpdateOne(filter, update);
                
                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Đăng ký thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành cô1ng");
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}