using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class Sign_up : System.Windows.Forms.Form
    {
        public Sign_up()
        {
            InitializeComponent();
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
        }

        private void Sign_up_Load(object sender, EventArgs e)
        { 
           Label[] labels= {label2,label3,label4,label5};
           Label[] label_titels= {label1,label6,label7,label8,label9,label10};
            foreach (Label label in label_titels)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
            }

            foreach (Label label in labels)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.Red;
                label.Text = "";
            }
        }
        private bool IsEmailExists(string email)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");

                // Filter to check if the email exists
                var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
                var result = collection.Find(filter).FirstOrDefault();

                // Return true if email exists, otherwise false
                return result != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking email: {ex.Message}");
                return false;
            }
        }

        private void textBox1_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label2.Text = "Vui lòng nhập tên của bạn";
            }
            else
            {
                label2.Text = "";
            }
        }

        private void textBox2_leave(object sender, EventArgs e)
        {
            string email = textBox2.Text;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label3.Text = "Vui lòng nhập email của bạn";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
            {
                label3.Text = "Email không hợp lệ";
            }
            else if (textBox2.Text.Length > 50)
            {
                label3.Text = "Email không được quá 50 ký tự";
            }
            else if (IsEmailExists(email))
            {
                label3.Text = "Email đã tồn tại";
            }
            else
            {
                label3.Text = "";
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                label4.Text = "Vui lòng số điện thoại của bạn";
            }
            else if (textBox3.Text.Length != 10 )
            {
                label4.Text = "số điện thoại phải là 10 số";
            }
            else
            {
                label4.Text = "";
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                label5.Text = "Vui lòng nhập mật khẩu của bạn";
            }
            else if (textBox4.Text.Length < 8)
            {
                label5.Text = "Mật khẩu phải có ít nhất 8 ký tự";
            }
            else
            {
                label5.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Retrive data from text boxes
            string name = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox4.Text;
            string confirmPassword = textBox5.Text;
            string phone = textBox3.Text;

            // Validate the input
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(phone))
            {
                label5.Text = "Vui lòng điền tất cả các thông tin";
                label2.ForeColor = Color.Red; 
                return;
            }
            else if (password != confirmPassword)
            {
                label5.Text = "Mật khẩu không khớp";
                return;
            }
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");
                // create a new customer    
                var document = new BsonDocument
                {
                    { "Name", name },
                    { "Email", email },
                    { "Password", password },
                    { "Phone", phone },
                    { "Bio",""},
                    { "Role", "users"},
                    { "Rank","Thành Viên"},
                    { "Seller_profile", new BsonDocument
                        {
                            {"is_seller",false},
                            { "Shop_name", "" },
                            { "Address", "" },
                            { "Shipping_company", "" },
                            { "Bank", ""},
                            { "Account_number", "" },
                        }
                    },
                    { "created_at", DateTime.UtcNow},
                    { "updated_at", DateTime.UtcNow}
                };
                // insert the document into the collection
                collection.InsertOne(document);
                // Show success message
                MessageBox.Show("Đăng ký thành công");
                this.Close();
            }
            catch(Exception ex)
            {
                 MessageBox.Show($"a error occured: {ex.Message}");
            };
        }
    }
}