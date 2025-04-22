using System;
using System.Globalization;
using System.Windows.Forms;
using MDBMS___E_COMMERCE_PLATFORM.Form.Shop;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public enum HomePage
    {
        PersonalManagement,
        ShopManagement,
    }

    public partial class Home : System.Windows.Forms.Form
    {
        private static string Key { get; set; }
        private BsonDocument Customer { get; set; }
        private bool IsSeller { get; set; }
        private MongoClient MongoClient { get; set; }
        private ConnectionMultiplexer RedisClient { get; set; }
        private HomePage CurrentPage { get; set; }

        public Home(string key)
        {
            Home.Key = key;
            InitializeComponent();
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
        }

        private static bool HasShop(BsonDocument customer)
        {
            return customer != null && customer["Seller_profile"]["is_seller"].AsBoolean;
        }

        private void UpdatePage(HomePage currentPage)
        {
            switch (currentPage)
            {
                case HomePage.PersonalManagement:
                    // Chuyển đến trang quản lý cá nhân
                    this.pictureBox1.Image = Properties.Resources.home_personal;
                    this.button1.Text = @"Sản phẩm";
                    this.button2.Text = @"Giỏ hàng của tôi";
                    this.button3.Text = @"Chuyển sang trang shop";
                    this.label6.Text = @"Tài khoản cá nhân";
                    label4.Text = Customer["Name"].AsString;
                    break;
                case HomePage.ShopManagement:
                    // Chuyển đến trang quản lý shop
                    this.pictureBox1.Image = Properties.Resources.home_shop;
                    this.button1.Text = @"Quản lý kho hàng";
                    this.button2.Text = @"Hóa đơn của tôi";
                    this.button3.Text = @"Chuyển sang trang cá nhân";
                    this.label6.Text = @"Tài khoản shop";
                    label4.Text = Customer["Seller_profile"]["Name"].AsString;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentPage), CurrentPage, null);
            }
        }


        /// Get the email from the session
        private string Get_email()
        {
            string[] parts = Key.Split(':');

            if (parts.Length > 2)
            {
                string email = parts[2];
                Console.WriteLine(@"Email extracted from session key: " + email);
                return email;
            }
            else
            {
                MessageBox.Show(@"Invalid session key format.");
            }

            return "";
        }

        private void GetCustomer()
        {
            try
            {
                this.MongoClient = new MongoClient("mongodb://localhost:27017");
                var database = MongoClient.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");
                var filter = Builders<BsonDocument>.Filter.Eq("Email", Get_email());
                this.Customer = collection.Find(filter).FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Something went wrong {e.Message}");
            }
        }

        // Method to toggle the textbox readonly property
        private void Home_Load(object sender, EventArgs e)
        {
            GetCustomer();
            this.IsSeller = HasShop(Customer);
            this.CurrentPage = HomePage.PersonalManagement;
            try
            {
                UpdatePage(this.CurrentPage);
                switch (this.IsSeller)
                {
                    case false:
                        button3.Hide();
                        break;
                    case true:
                        button3.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Something went wrong {ex.Message}");
            }
        }

        /// Method to close the session in Redis
        private void Closed_session()
        {
            try
            {
                this.RedisClient = ConnectionMultiplexer.Connect("localhost");
                var db = RedisClient.GetDatabase(0);
                // Get the session key
                string closedAt = db.HashGet(Key, "closed_at");
                // Update the session in Redis
                db.HashSet(Key, new HashEntry[]
                {
                    new HashEntry("closed_at", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Something went wrong {ex.Message}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

            if (this.IsSeller)
            {
                var seller = new Seller_Profile(Customer);
                seller.ShowDialog();
            }
            else
            {
                var personal = new Personal_information(Customer, Key);
                personal.ShowDialog();
                label4.Text = Customer["Name"].AsString;
            }
            this.Home_Load(sender, e);
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
            if (CurrentPage == HomePage.PersonalManagement)
            {
                Product addToCartForm = new Product(email);
                addToCartForm.ShowDialog();
                // Dùng ShowDialog để mở form giỏ hàng như một modal dialog
            }
            else
            {
                var storagePage = new Storage(email, this.MongoClient);
                storagePage.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var email = Get_email();
            Console.WriteLine(email);
            if (CurrentPage == HomePage.PersonalManagement)
            {
                // Khi nút Add to Cart được nhấn, mở form AddToCart
                Cart cart = new Cart(email);
                cart.ShowDialog(); // Dùng ShowDialog để mở form giỏ hàng như một modal dialog
            }
            else
            {
                var invoicePage = new Invoice(email, this.MongoClient);
                invoicePage.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurrentPage = CurrentPage == HomePage.PersonalManagement
                ? HomePage.ShopManagement
                : HomePage.PersonalManagement;
            UpdatePage(CurrentPage);
        }
    }
}