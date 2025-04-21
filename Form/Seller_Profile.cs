using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class Seller_Profile : System.Windows.Forms.Form
    {
        public static BsonDocument Seller { get; set; }
        public static Boolean isEdit = false;
        
        public Seller_Profile(BsonDocument cutomer)
        {
            
            InitializeComponent();
            Seller = cutomer;
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
        }
        private void ToggleTextBoxReadOnly( )
        {
            TextBox[] textBoxes = {textBox1,textBox2,textBox3,textBox4,textBox5,textBox6,textBox7,textBox8};
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enabled = !textBox.Enabled;
            }
            comboBox1.Enabled = !comboBox1.Enabled;
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
        private void Seller_Profile_Load(object sender, EventArgs e)
        {
            try
            {
                ToggleTextBoxReadOnly();
                SetupComboBox();
                textBox1.Text = Seller["Seller_profile"]["Name"].AsString;
                textBox2.Text = Seller["Seller_profile"]["Address"].AsString;
                textBox3.Text = Seller["Name"].AsString;
                textBox4.Text = Seller["Phone"].AsString;
                textBox5.Text = Seller["Email"].AsString;
                textBox6.Text = Seller["Bio"].AsString;
                textBox7.Text = Seller["Seller_profile"]["Bank"].AsString;
                textBox8.Text = Seller["Seller_profile"]["Account_number"].AsString;
                comboBox1.SelectedItem = Seller["Seller_profile"]["Shipping_Method"].AsString;    
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading seller profile: " + ex.Message);
            }
            
        }

        private void UpdateSellerInfor(BsonDocument Seller)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection = database.GetCollection<BsonDocument>("information_customers");

                var filter = Builders<BsonDocument>.Filter.Eq("Email", Seller["Email"].AsString);
                var update = Builders<BsonDocument>.Update
                    .Set("Seller_profile.Name", Seller["Seller_profile"]["Name"].AsString)
                    .Set("Seller_profile.Address", Seller["Seller_profile"]["Address"].AsString)
                    .Set("Name", Seller["Name"].AsString)
                    .Set("Phone", Seller["Phone"].AsString)
                    .Set("Email", Seller["Email"].AsString)
                    .Set("Bio", Seller["Bio"].AsString)
                    .Set("Seller_profile.Shipping_Method", Seller["Seller_profile"]["Shipping_Method"].AsString)
                    .Set("Seller_profile.Bank", Seller["Seller_profile"]["Bank"].AsString)
                    .Set("Seller_profile.Account_number", Seller["Seller_profile"]["Account_number"].AsString)
                    .Set("updated_at", DateTime.UtcNow);
                var result = collection.UpdateOne(filter, update);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            ToggleTextBoxReadOnly();
            if (isEdit == false)
            {
                label7.Text = "Lưu";
                isEdit = true;
            }
            else
            {
                label7.Text = "chỉnh sửa";
                isEdit = false;
                Seller["Seller_profile"]["Name"] = textBox1.Text;
                Seller["Seller_profile"]["Address"] = textBox2.Text;
                Seller["Name"] = textBox3.Text;
                Seller["Phone"] = textBox4.Text;
                Seller["Email"] = textBox5.Text;
                Seller["Bio"] = textBox6.Text;
                Seller["Seller_profile"]["Shipping_Method"] = comboBox1.SelectedItem.ToString();
                Seller["Seller_profile"]["Bank"] = textBox7.Text;
                Seller["Seller_profile"]["Account_number"] = textBox8.Text;
                UpdateSellerInfor(Seller);
            }
            
        }
    }
}