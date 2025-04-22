using System;
using System.Globalization;
using System.Windows.Forms;
using MDBMS___E_COMMERCE_PLATFORM.Repository.Entity;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form.Shop
{
    public partial class Sale : System.Windows.Forms.Form
    {
        private readonly ProductDto _product;
        private MongoClient MongoClient { get; set; }

        private IMongoDatabase MongoDatabase { get; set; }

        public Sale(ProductDto product, MongoClient client)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            _product = product;
            MongoClient = client;
            MongoDatabase = MongoClient.GetDatabase("e-commerce");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            RefreshPrice();
        }

        private void RefreshPrice()
        {
            label1.Text = $@"Product name: {_product.Name}";
            label2.Text = $@"Original Price: {_product.Price}";
            label3.Text = $@"Discount Price: {_product.Price - (_product.Price * numericUpDown1.Value / 100)}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(dateTimePicker1.Value.ToString(CultureInfo.InvariantCulture), null,
                DateTimeStyles.RoundtripKind);
            DateTime endDate = DateTime.Parse(dateTimePicker2.Value.ToString(CultureInfo.InvariantCulture), null,
                DateTimeStyles.RoundtripKind);
            decimal percent = numericUpDown1.Value;
            if (!SaleDto.IsValidSaleInfo(percent, startDate, endDate))
            {
                MessageBox.Show($@"Invalid sale datetime input or percent value.");
                return;
            }

            try
            {
                ProductDto updateProduct = new ProductDto(
                    _product.Id,
                    _product.Name,
                    _product.ProductType,
                    _product.Category,
                    _product.Price,
                    _product.Stock,
                    _product.Description,
                    _product.SellerId,
                    percent,
                    startDate,
                    endDate
                );
                var productCollection = MongoDatabase.GetCollection<ProductDto>("products");
                productCollection.DeleteOne(Builders<ProductDto>.Filter.And(
                    Builders<ProductDto>.Filter.Eq("seller_id", _product.SellerId),
                    Builders<ProductDto>.Filter.Eq("name", _product.Name)
                ));
                productCollection.InsertOne(updateProduct);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Invalid sale datetime input or percent value.");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}