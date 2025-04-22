using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class InitForm : System.Windows.Forms.Form
    {
        private static string key {get; set; }
        public InitForm()
        {
            InitializeComponent();
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
            textBox2.PasswordChar = '*';
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.White;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Red;
            label4.Text = "";
        }
        /// Method to store session in Redis
        private void StoreSession(string email)
        {
            try
            {
                // Create a unique key for the session
                key = "session:" + Guid.NewGuid().ToString() + ":" + email;
                string created_value = DateTime.UtcNow.AddMinutes(30).ToString();
                // Store the session in Redis
                var redis = ConnectionMultiplexer.Connect("localhost");
                var db = redis.GetDatabase(0);
                // 
                db.HashSet(key, new HashEntry[]
                {
                    new HashEntry("created_at", created_value),
                    new HashEntry("closed_at", "")
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show ($"Something went wrong {ex.Message}");
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            string password = textBox2.Text;
            
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
            {
                label4.Text = "Vui lòng điền thông tin đăng nhập!";
                return;
            }

            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");

                var filter = Builders<BsonDocument>.Filter.Eq("Email", Email);
                var user = collection.Find(filter).FirstOrDefault();

                if (user != null)
                {
                    var storedPassword = user["Password"].AsString;
                    if (storedPassword == password)
                    {
                        // Store session in Redis
                        StoreSession(Email);
                        label4.Text = "Đăng nhập thành công!";
                        this.Hide();
                        var homeForm = new Home(key);
                        homeForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        label4.Text = "Mật khẩu không đúng!";
                    }
                }
                else
                {
                    label4.Text = "Tài khoản không tồn tại!";
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show($"A error occured {ex.Message}");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var signUpForm = new Sign_up();
            signUpForm.ShowDialog();
        }
        
    }
}
