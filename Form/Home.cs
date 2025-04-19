using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    public partial class Home : Form
    {
        public static string Key { get; set; }
        public static BsonDocument customer {get;set;}
        public Home(string key)
        {
            Home.Key = key;
            InitializeComponent();
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
        }
        

        /// Get the email from the session
        private string Get_email()
        {
            string[] parts = Key.Split(':');
            
            if (parts.Length > 2)
            {
                string email = parts[2];
                Console.WriteLine("Email extracted from session key: " + email);
                return email;
            }
            else
            {
                MessageBox.Show("Invalid session key format.");
            }
            return "";
        }

        private void GetCustomer()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");
                var filter = Builders<BsonDocument>.Filter.Eq("Email", Get_email());
                customer = collection.Find(filter).FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Something went wrong {e.Message}");
            }
        }
        // Method to toggle the textbox readonly property
        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                GetCustomer();
                if (customer != null && !customer["Seller_profile"]["is_seller"].AsBoolean)
                {
                    // Set the text of the label to the customer's name
                    label4.Text = customer["Name"].AsString;
                }
                else if (customer != null && customer["Seller_profile"]["is_seller"].AsBoolean)
                {
                    // Set the text of the label to the customer's name
                    label4.Text = customer["Seller_profile"]["Name"].AsString;
                }

                else
                {
                    MessageBox.Show("Invalid session key format.");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Something went wrong {ex.Message}");
            }
        }
        /// Method to close the session in Redis
        private void Closed_session()
        {
            try
            {
                var redis = ConnectionMultiplexer.Connect("localhost");
                var db = redis.GetDatabase(0);
                // Get the session key
                string closedAt = db.HashGet(Key, "closed_at");
                // Update the session in Redis
                db.HashSet(Key, new HashEntry[]
                {
                    new HashEntry("closed_at", DateTime.UtcNow.ToString())
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Shomething went wrong {ex.Message}");
            }
            
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (customer["Seller_profile"]["is_seller"].AsBoolean)
            {
                var seller = new Seller_Profile(customer);
                seller.ShowDialog();
                GetCustomer();
                label4.Text = customer["Seller_profile"]["Name"].AsString;
            }
            else
            {
                var personal = new Personal_information(customer, Key);
                personal.ShowDialog();
                GetCustomer();
                label4.Text = customer["Name"].AsString;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Closed_session();
            this.Hide();
            var login = new InitForm();
            login.ShowDialog();
            this.Close();
        }
        // Chuyển qua form Sản phẩm
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            string email = Get_email();
            // Khi nút Add to Cart được nhấn, mở form AddToCart
            Console.WriteLine(email);
            Product addToCartForm = new Product(email);
            addToCartForm.ShowDialog(); // Dùng ShowDialog để mở form giỏ hàng như một modal dialog
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}