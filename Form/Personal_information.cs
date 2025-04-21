using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    public partial class Personal_information : System.Windows.Forms.Form
    {
        public static BsonDocument Cusomter { get; set; }
        public static string Key { get; set; }
        public static Boolean isEdit = false;
        public Personal_information(BsonDocument customer,string key)
        {
            InitializeComponent();
            Cusomter = customer;
            Key = key;
            // Ngăn thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Vô hiệu hóa nút phóng to
            this.MaximizeBox = false;
        }
        private void ToggleTextBoxReadOnly( )
        {
            TextBox[] textBoxes = {textBox1,textBox2,textBox3,textBox4};
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enabled = !textBox.Enabled;
            }
        }
        private void UpdateCustomerInfo(BsonDocument customer)
        {
            try
            {
                // Cập nhật thông tin khách hàng vào cơ sở dữ liệu
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("e-commerce");
                var collection =database.GetCollection<BsonDocument>("information_customers");
                var filter = Builders<BsonDocument>.Filter.Eq("Email", customer["Email"].AsString);
            
                var update = Builders<BsonDocument>.Update
                    .Set("Name", customer["Name"].AsString)
                    .Set("Phone", customer["Phone"].AsString)
                    .Set("Bio", customer["Bio"].AsString)
                    .Set("updated_at", DateTime.UtcNow);
                var result = collection.UpdateOne(filter, update);
            
                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Customer information updated successfully.");
                }
                else
                {
                    MessageBox.Show("No changes were made to the customer information.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer information: " + ex.Message);
            }
        }
        private void Personal_information_Load(object sender, EventArgs e)
        {
            ToggleTextBoxReadOnly();
            textBox1.Text = Cusomter["Name"].ToString();
            textBox2.Text = Cusomter["Email"].ToString();
            textBox3.Text = Cusomter["Phone"].ToString();
            textBox4.Text = Cusomter["Bio"].ToString();
            label6.Text = Cusomter["Rank"].ToString();
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
                Cusomter["Name"] = textBox1.Text;
                Cusomter["Email"] = textBox2.Text;
                Cusomter["Phone"] = textBox3.Text;
                Cusomter["Bio"] = textBox4.Text;
                UpdateCustomerInfo(Cusomter);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
             this.Hide();
             var form = new sign_up_seller(Key);
             form.ShowDialog();
        }
    }
}