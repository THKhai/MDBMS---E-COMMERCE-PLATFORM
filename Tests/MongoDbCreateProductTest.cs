using System.Collections.Generic;
using System.Threading.Tasks;
using MDBMS___E_COMMERCE_PLATFORM.Form.Shop;
using MDBMS___E_COMMERCE_PLATFORM.Repository.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

namespace MDBMS___E_COMMERCE_PLATFORM.Tests
{
    public class MongoDbCreateProductTest
    {
        [Test]
        public void Given_5_user_100_row_for_create_product()
        {
            // Arrange
            List<string> listUserId = new List<string>();

            var user1 = new Storage("toantu03@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user2 = new Storage("emma.gadget@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user3 = new Storage("sophia.style@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user4 = new Storage("oliver.books@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user5 = new Storage("mia.decor@gmail.com", new MongoClient("mongodb://localhost:27017"));

            var id1 = user1.ExtractUserId("toantu03@gmail.com");
            var id2 = user2.ExtractUserId("emma.gadget@gmail.com");
            var id3 = user3.ExtractUserId("sophia.style@gmail.com");
            var id4 = user4.ExtractUserId("oliver.books@gmail.com");
            var id5 = user5.ExtractUserId("mia.decor@gmail.com");

            listUserId.Add(id1);
            listUserId.Add(id2);
            listUserId.Add(id3);
            listUserId.Add(id4);
            listUserId.Add(id5);
            var client = new MongoClient("mongodb://localhost:27017");

            // Inject the simulated DataGridView into the form
            Parallel.For(0, listUserId.Count, i =>
            {
                // Process data in parallel
                var database = client.GetDatabase("e-commerce");
                var productCollection = database.GetCollection<ProductDto>("products");
                var productList = new List<ProductDto>();
                for (int j = 0; j < 100; j += 1) // Simulate 100 products
                {
                    ProductDto product = new ProductDto(ObjectId.GenerateNewId().ToString(), "Category1", "Type1",
                        "Description1",
                        100,
                        10, "", listUserId[i]);
                    productList.Add(product);
                }

                productCollection.DeleteManyAsync(Builders<ProductDto>.Filter.Eq("seller_id", listUserId[i]));
                productCollection.InsertManyAsync(productList).Wait();
            });
        }

        [Test]
        public void Given_5_user_1000_row_for_create_product()
        {
            // Arrange
            List<string> listUserId = new List<string>();

            var user1 = new Storage("toantu03@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user2 = new Storage("emma.gadget@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user3 = new Storage("sophia.style@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user4 = new Storage("oliver.books@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user5 = new Storage("mia.decor@gmail.com", new MongoClient("mongodb://localhost:27017"));

            var id1 = user1.ExtractUserId("toantu03@gmail.com");
            var id2 = user2.ExtractUserId("emma.gadget@gmail.com");
            var id3 = user3.ExtractUserId("sophia.style@gmail.com");
            var id4 = user4.ExtractUserId("oliver.books@gmail.com");
            var id5 = user5.ExtractUserId("mia.decor@gmail.com");

            listUserId.Add(id1);
            listUserId.Add(id2);
            listUserId.Add(id3);
            listUserId.Add(id4);
            listUserId.Add(id5);
            var client = new MongoClient("mongodb://localhost:27017");

            // Inject the simulated DataGridView into the form
            Parallel.For(0, listUserId.Count, i =>
            {
                // Process data in parallel
                var database = client.GetDatabase("e-commerce");
                var productCollection = database.GetCollection<ProductDto>("products");
                var productList = new List<ProductDto>();
                for (int j = 0; j < 1000; j += 1) // Simulate 100 products
                {
                    ProductDto product = new ProductDto(ObjectId.GenerateNewId().ToString(), "Category1", "Type1",
                        "Description1",
                        100,
                        10, "", listUserId[i]);
                    productList.Add(product);
                }

                productCollection.DeleteManyAsync(Builders<ProductDto>.Filter.Eq("seller_id", listUserId[i]));
                productCollection.InsertManyAsync(productList).Wait();
            });
        }

        [Test]
        public void Given_5_user_10000_row_for_create_product()
        {
            // Arrange
            List<string> listUserId = new List<string>();

            var user1 = new Storage("toantu03@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user2 = new Storage("emma.gadget@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user3 = new Storage("sophia.style@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user4 = new Storage("oliver.books@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user5 = new Storage("mia.decor@gmail.com", new MongoClient("mongodb://localhost:27017"));

            var id1 = user1.ExtractUserId("toantu03@gmail.com");
            var id2 = user2.ExtractUserId("emma.gadget@gmail.com");
            var id3 = user3.ExtractUserId("sophia.style@gmail.com");
            var id4 = user4.ExtractUserId("oliver.books@gmail.com");
            var id5 = user5.ExtractUserId("mia.decor@gmail.com");

            listUserId.Add(id1);
            listUserId.Add(id2);
            listUserId.Add(id3);
            listUserId.Add(id4);
            listUserId.Add(id5);
            var client = new MongoClient("mongodb://localhost:27017");

            // Inject the simulated DataGridView into the form
            Parallel.For(0, listUserId.Count, i =>
            {
                // Process data in parallel
                var database = client.GetDatabase("e-commerce");
                var productCollection = database.GetCollection<ProductDto>("products");
                var productList = new List<ProductDto>();
                for (int j = 0; j < 10000; j += 1) // Simulate 100 products
                {
                    ProductDto product = new ProductDto(ObjectId.GenerateNewId().ToString(), "Category1", "Type1",
                        "Description1",
                        100,
                        10, "", listUserId[i]);
                    productList.Add(product);
                }

                productCollection.DeleteManyAsync(Builders<ProductDto>.Filter.Eq("seller_id", listUserId[i]));
                productCollection.InsertManyAsync(productList).Wait();
            });
        }

        [Test]
        public void Given_5_user_100000_row_for_create_product()
        {
            // Arrange
            List<string> listUserId = new List<string>();

            var user1 = new Storage("toantu03@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user2 = new Storage("emma.gadget@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user3 = new Storage("sophia.style@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user4 = new Storage("oliver.books@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user5 = new Storage("mia.decor@gmail.com", new MongoClient("mongodb://localhost:27017"));

            var id1 = user1.ExtractUserId("toantu03@gmail.com");
            var id2 = user2.ExtractUserId("emma.gadget@gmail.com");
            var id3 = user3.ExtractUserId("sophia.style@gmail.com");
            var id4 = user4.ExtractUserId("oliver.books@gmail.com");
            var id5 = user5.ExtractUserId("mia.decor@gmail.com");

            listUserId.Add(id1);
            listUserId.Add(id2);
            listUserId.Add(id3);
            listUserId.Add(id4);
            listUserId.Add(id5);
            var client = new MongoClient("mongodb://localhost:27017");

            // Inject the simulated DataGridView into the form
            Parallel.For(0, listUserId.Count, i =>
            {
                // Process data in parallel
                var database = client.GetDatabase("e-commerce");
                var productCollection = database.GetCollection<ProductDto>("products");
                var productList = new List<ProductDto>();
                for (int j = 0; j < 100000; j += 1) // Simulate 100 products
                {
                    ProductDto product = new ProductDto(ObjectId.GenerateNewId().ToString(), "Category1", "Type1",
                        "Description1",
                        100,
                        10, "", listUserId[i]);
                    productList.Add(product);
                }

                productCollection.DeleteManyAsync(Builders<ProductDto>.Filter.Eq("seller_id", listUserId[i]));
                productCollection.InsertManyAsync(productList).Wait();
            });
        }

        [Test]
        public void Given_5_user_900000_row_for_create_product()
        {
            // Arrange
            List<string> listUserId = new List<string>();

            var user1 = new Storage("toantu03@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user2 = new Storage("emma.gadget@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user3 = new Storage("sophia.style@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user4 = new Storage("oliver.books@gmail.com", new MongoClient("mongodb://localhost:27017"));
            var user5 = new Storage("mia.decor@gmail.com", new MongoClient("mongodb://localhost:27017"));

            var id1 = user1.ExtractUserId("toantu03@gmail.com");
            var id2 = user2.ExtractUserId("emma.gadget@gmail.com");
            var id3 = user3.ExtractUserId("sophia.style@gmail.com");
            var id4 = user4.ExtractUserId("oliver.books@gmail.com");
            var id5 = user5.ExtractUserId("mia.decor@gmail.com");

            listUserId.Add(id1);
            listUserId.Add(id2);
            listUserId.Add(id3);
            listUserId.Add(id4);
            listUserId.Add(id5);
            var client = new MongoClient("mongodb://localhost:27017");

            // Inject the simulated DataGridView into the form
            Parallel.For(0, listUserId.Count, i =>
            {
                // Process data in parallel
                var database = client.GetDatabase("e-commerce");
                var productCollection = database.GetCollection<ProductDto>("products");
                var productList = new List<ProductDto>();
                for (int j = 0; j < 800000; j += 1) // Simulate 100 products
                {
                    ProductDto product = new ProductDto(ObjectId.GenerateNewId().ToString(), "Category1", "Type1",
                        "Description1",
                        100,
                        10, "", listUserId[i]);
                    productList.Add(product);
                }

                productCollection.DeleteManyAsync(Builders<ProductDto>.Filter.Eq("seller_id", listUserId[i]));
                productCollection.InsertManyAsync(productList).Wait();
            });
        }
    }
}