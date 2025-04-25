using System.Collections;
using CouchDB.Driver.Types;
using Newtonsoft.Json;

namespace MDBMS___E_COMMERCE_PLATFORM.Repository.Entity
{
    public class ProductDtoCouch : CouchDocument
    {
        public ProductDtoCouch(string name,string category, string productType, string description, decimal price, int stock, string sellerId)
        {
            Category = category;
            Name = name;
            Description = description;
            Price = price;
            ProductType = productType;
            Stock = stock;
            SellerId = sellerId;
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("product_type")] public string ProductType { get; set; }
        [JsonProperty("category")] public string Category { get; set; }
        [JsonProperty("price")] public decimal Price { get; set; }
        [JsonProperty("stock")] public int Stock { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("seller_id")] public string SellerId { get; set; }
    }
}