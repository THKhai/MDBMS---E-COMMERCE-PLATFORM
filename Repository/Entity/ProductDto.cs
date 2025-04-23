using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MDBMS___E_COMMERCE_PLATFORM.Repository.Entity
{
    public class ProductDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")] public string Name { get; set; }
        [BsonElement("product_type")] public string ProductType { get; set; }
        [BsonElement("category")] public string Category { get; set; }
        [BsonElement("price")] public decimal Price { get; set; }
        [BsonElement("stock")] public int Stock { get; set; }
        [BsonElement("description")] public string Description { get; set; }
        [BsonElement("seller_id")] public string SellerId { get; set; }
        [BsonElement("sale")] public SaleDto Sale { get; set; }

        public ProductDto(
            string id,
            string name,
            string productType,
            string category,
            decimal price,
            int stock,
            string description,
            string sellerId,
            decimal? salePercent = null,
            DateTime? startDate = null,
            DateTime? endDate = null
        )
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) || price < 0 || stock < 0)
            {
                throw new ArgumentException("Invalid product information");
            }

            Id = id;
            Name = name;
            Description = description;
            ProductType = productType;
            Price = price;
            Stock = stock;
            Category = category;
            SellerId = sellerId;
            Sale = null;
            if (
                salePercent != null
                && startDate != null
                && endDate != null
                && SaleDto.IsValidSaleInfo(salePercent.Value, startDate.Value, endDate.Value)
            )
            {
                Sale = new SaleDto(salePercent.Value, startDate.Value, endDate.Value);
            }
        }

        private static decimal CalculateSalePrice(ProductDto product)
        {
            if (product.Sale == null) return 0;
            var salePrice = product.Price * (1 - (product.Sale.Percent / 100));
            return salePrice;
        }

        public static void MapToDataGridView(DataGridView dataGridView, List<ProductDto> products)
        {
            dataGridView.Rows.Clear();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Type productDtoType = typeof(ProductDto);
            var productDtoProperties = productDtoType.GetProperties();
            dataGridView.ColumnCount = productDtoProperties.Length - 3;

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].Name = productDtoProperties[i + 1].Name;
            }

            foreach (ProductDto product in products)
            {
                var salePrice = CalculateSalePrice(product);
                if (salePrice > 0 && SaleDto.IsSaleActive(product.Sale))
                {
                    var rowIndex = dataGridView.Rows.Add(product.Name,
                        product.ProductType,
                        product.Category,
                        salePrice,
                        product.Stock,
                        product.Description);
                    dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Blue;
                    dataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
                }
                else
                {
                    dataGridView.Rows.Add(product.Name, product.ProductType, product.Category, product.Price,
                        product.Stock, product.Description);
                }
            }
        }
    }
}