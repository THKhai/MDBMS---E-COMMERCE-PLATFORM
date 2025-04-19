using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    public partial class Cart : Form
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;

        public Cart()
        {
            InitializeComponent();

            // Ngăn resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Kết nối MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("e-commerce");
            _productCollection = db.GetCollection<BsonDocument>("products");
            // var product = _productCollection.Find(new BsonDocument()).FirstOrDefault(); // Tìm một sản phẩm
            // if (product != null)
            // {
            //     Console.WriteLine($"Product found: {product["name"]}"); // Kiểm tra xem sản phẩm có tồn tại không
            // }
            // else
            // {
            //     Console.WriteLine("No product found.");
            // }
        }

        private void FormAddToCart_Load(object sender, EventArgs e)
        {
            LoadProductList();
            nudQuantity.Value = 1;
        }

        private void LoadProductList()
        {
            dgvProducts.Rows.Clear();
            var products = _productCollection.Find(new BsonDocument()).ToList();

            // Duyệt qua tất cả sản phẩm và thêm vào DataGridView
            foreach (var product in products)
            {
                // Lấy các thông tin cơ bản của sản phẩm
                string name = product.GetValue("name", "").AsString;
                string category = product.GetValue("category", "").AsString;
                string price = product.GetValue("price", 0).ToString();

                // Lấy các thuộc tính sản phẩm
                BsonDocument attributes = product.GetValue("attributes", new BsonDocument()).AsBsonDocument;

                // Khởi tạo danh sách các cột (attribute) để điền vào DataGridView
                string size = attributes.Contains("size") ? attributes["size"].ToString() : "";
                string color = attributes.Contains("color") ? attributes["color"].ToString() : "";
                string brand = attributes.Contains("brand") ? attributes["brand"].ToString() : "";
                string material = attributes.Contains("material") ? attributes["material"].ToString() : "";
                string warranty = attributes.Contains("warranty") ? attributes["warranty"].ToString() : "";
                // string cpu = attributes.Contains("cpu") ? attributes["cpu"].ToString() : "";
                // string ram = attributes.Contains("ram") ? attributes["ram"].ToString() : "";
                // string storage = attributes.Contains("storage") ? attributes["storage"].ToString() : "";

                // Thêm dòng vào DataGridView với các cột attribute
                dgvProducts.Rows.Add(name, category, price, size, color, material, brand, warranty);
            }

            dgvProducts.ClearSelection();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                string name = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                string category = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                int price = Convert.ToInt32(dgvProducts.CurrentRow.Cells[2].Value);
                int quantity = (int)nudQuantity.Value;

                MessageBox.Show($"Đã thêm: {name} x{quantity} = {price * quantity:N0}đ",
                    "Thêm vào giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TODO: Thêm vào danh sách giỏ hàng (RAM hoặc Redis)
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
