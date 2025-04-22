using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MDBMS___E_COMMERCE_PLATFORM.Repository.Entity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form.Shop
{
    public partial class Storage : System.Windows.Forms.Form
    {
        private MongoClient MongoClient { get; set; }
        private string UserEmail { get; set; }
        private IMongoDatabase MongoDatabase { get; set; }

        private string UserId { get; set; }

        private List<ProductDto> _shopProducts = null;

        public Storage(string email, MongoClient client)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MongoClient = client;
            UserEmail = email;
            MongoDatabase = MongoClient.GetDatabase("e-commerce");
            UserId = ExtractUserId(UserEmail);
        }

        private void Storage_Load(object sender, EventArgs e)
        {
            LoadShopItems();
        }

        private void LoadShopItems()
        {
            var productCollection = MongoDatabase.GetCollection<ProductDto>("products");
            var filterShopItem = Builders<ProductDto>.Filter.Eq("seller_id", UserId);
            _shopProducts = productCollection.Find(filterShopItem).ToList();
            ProductDto.MapToDataGridView(ProductGridView, _shopProducts);
        }

        private string ExtractUserId(string email)
        {
            var collection = MongoDatabase.GetCollection<BsonDocument>("information_customers");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            var user = collection.Find(filter).FirstOrDefault();
            return user?["_id"].ToString();
        }

        public string GetProductId(string productName)
        {
            foreach (ProductDto product in _shopProducts)
            {
                if (String.Equals(product.Name, productName))
                {
                    return product.Id;
                }
            }

            return ObjectId.GenerateNewId().ToString();
        }

        public SaleDto GetSaleInfo(string productName)
        {
            foreach (ProductDto product in _shopProducts)
            {
                if (String.Equals(product.Name, productName))
                {
                    return product.Sale;
                }
            }

            return null;
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            List<ProductDto> incomingProductDatas = new List<ProductDto>();
            foreach (DataGridViewRow row in ProductGridView.Rows)
            {
                try
                {
                    if (row.Cells["Name"].Value == null) continue;
                    if (string.IsNullOrEmpty(row.Cells["Name"].Value.ToString())) continue;
                    var productCategory = row.Cells["Category"].Value == null
                        ? ""
                        : row.Cells["Category"].Value.ToString();
                    ;
                    var productType = row.Cells["ProductType"].Value == null
                        ? ""
                        : row.Cells["ProductType"].Value.ToString();
                    ;
                    var productDescription = row.Cells["Description"].Value == null
                        ? ""
                        : row.Cells["Description"].Value.ToString();
                    ;
                    var productId = GetProductId(row.Cells["Name"].Value.ToString());
                    var saleInfo = GetSaleInfo(row.Cells["Name"].Value.ToString());
                    ProductDto currentProduct;
                    if (saleInfo != null)
                    {
                        decimal originalPrice = decimal.Parse(row.Cells["Price"].Value.ToString()) /
                                                (1 - (saleInfo.Percent / 100));
                        if (!SaleDto.IsSaleActive(saleInfo))
                            originalPrice = decimal.Parse(row.Cells["Price"].Value.ToString());
                        currentProduct = new ProductDto(
                            productId,
                            row.Cells["Name"].Value.ToString(),
                            productType,
                            productCategory,
                            originalPrice,
                            int.Parse(row.Cells["Stock"].Value.ToString()),
                            productDescription,
                            UserId,
                            saleInfo.Percent,
                            saleInfo.StartDate,
                            saleInfo.EndDate);
                    }
                    else
                    {
                        currentProduct = new ProductDto(
                            productId,
                            row.Cells["Name"].Value.ToString(),
                            productType,
                            productCategory,
                            decimal.Parse(row.Cells["Price"].Value.ToString()),
                            int.Parse(row.Cells["Stock"].Value.ToString()),
                            productDescription,
                            UserId);
                    }

                    incomingProductDatas.Add(currentProduct);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($@"Missing or Invalid product information or Product name duplicate");
                    LoadShopItems();
                    return;
                }
            }

            _shopProducts.Clear();
            _shopProducts.AddRange(incomingProductDatas);
            var productCollection = MongoDatabase.GetCollection<ProductDto>("products");
            productCollection.DeleteMany(Builders<ProductDto>.Filter.Eq("seller_id", UserId));
            productCollection.InsertMany(_shopProducts);
            MessageBox.Show(@"Products updated successfully");
            LoadShopItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ProductGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ProductGridView
                    .Rows[ProductGridView.CurrentCell.RowIndex]
                    .Cells["Name"]
                    .Value == null) return;
            string currentProductName = ProductGridView
                .Rows[ProductGridView.CurrentCell.RowIndex]
                .Cells["Name"]
                .Value
                .ToString();
            var productCollection = MongoDatabase.GetCollection<ProductDto>("products");
            var filterShopItem = Builders<ProductDto>.Filter.And(
                Builders<ProductDto>.Filter.Eq("seller_id", UserId),
                Builders<ProductDto>.Filter.Eq("name", currentProductName)
            );
            ProductDto product = productCollection.Find(filterShopItem).FirstOrDefault();
            Sale saleForm = new Sale(product, MongoClient);
            saleForm.ShowDialog();
            LoadShopItems();
        }
    }
}