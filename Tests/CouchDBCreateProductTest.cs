using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouchDB.Driver;
using MDBMS___E_COMMERCE_PLATFORM.Form.Shop;
using MDBMS___E_COMMERCE_PLATFORM.Repository.Entity;
using MongoDB.Driver;
using NUnit.Framework;

namespace MDBMS___E_COMMERCE_PLATFORM.Tests
{
    public class CouchDbCreateProductTest
    {
        [Test]
        public void Given_5_user_100_row_for_create_product()
        {
            var client = new CouchClient("http://localhost:5984",
                settings => { settings.UseBasicAuthentication("admin", "admin"); });
            client.CreateDatabaseAsync<ProductDtoCouch>("e-commerce");
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

            var database = client.GetDatabase<ProductDtoCouch>("e-commerce");
            // Process each user in parallel:
            Parallel.For(0, listUserId.Count, i =>
            {
                // Build a list with 100 simulated products for the user.
                var productList = new List<ProductDtoCouch>();
                for (int j = 0; j < 100; j++)
                {
                    var product = new ProductDtoCouch(
                        Guid.NewGuid().ToString(),
                        "Category1",
                        "Type1",
                        "Description1",
                        100,
                        10,
                        listUserId[i]
                    );
                    productList.Add(product);
                }

                // Delete existing products for the current user.
                var productsToDelete = database
                    .Where(p => p.SellerId == listUserId[i])
                    .ToList();
                foreach (ProductDtoCouch product in productsToDelete)
                {
                    database.DeleteAsync(product).Wait();
                }

                // Insert new products by iterating over the productList.
                database.CreateOrUpdateRangeAsync(productList).Wait();
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

            var client = new CouchClient("http://localhost:5984",
                settings => { settings.UseBasicAuthentication("admin", "admin"); });
            var database = client.GetDatabase<ProductDtoCouch>("e-commerce");
            // Process each user in parallel:
            Parallel.For(0, listUserId.Count, i =>
            {
                // Build a list with 100 simulated products for the user.
                var productList = new List<ProductDtoCouch>();
                for (int j = 0; j < 1000; j++)
                {
                    var product = new ProductDtoCouch(
                        Guid.NewGuid().ToString(),
                        "Category1",
                        "Type1",
                        "Description1",
                        100,
                        10,
                        listUserId[i]
                    );
                    productList.Add(product);
                }

                // Delete existing products for the current user.
                var productsToDelete = database
                    .Where(p => p.SellerId == listUserId[i])
                    .ToList();
                foreach (ProductDtoCouch product in productsToDelete)
                {
                    database.DeleteAsync(product).Wait();
                }

                // Insert new products by iterating over the productList.
                database.CreateOrUpdateRangeAsync(productList).Wait();
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

            var client = new CouchClient("http://localhost:5984",
                settings => { settings.UseBasicAuthentication("admin", "admin"); });
            var database = client.GetDatabase<ProductDtoCouch>("e-commerce");
            // Process each user in parallel:
            Parallel.For(0, listUserId.Count, i =>
            {
                // Build a list with 100 simulated products for the user.
                var productList = new List<ProductDtoCouch>();
                for (int j = 0; j < 10000; j++)
                {
                    var product = new ProductDtoCouch(
                        Guid.NewGuid().ToString(),
                        "Category1",
                        "Type1",
                        "Description1",
                        100,
                        10,
                        listUserId[i]
                    );
                    productList.Add(product);
                }

                // Delete existing products for the current user.
                var productsToDelete = database
                    .Where(p => p.SellerId == listUserId[i])
                    .ToList();
                foreach (ProductDtoCouch product in productsToDelete)
                {
                    database.DeleteAsync(product).Wait();
                }

                // Insert new products by iterating over the productList.

                database.CreateOrUpdateRangeAsync(productList).Wait();
            });
            client.DeleteDatabaseAsync<ProductDtoCouch>("e-commerce");
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

            var client = new CouchClient("http://localhost:5984",
                settings => { settings.UseBasicAuthentication("admin", "admin"); });
            client.CreateDatabaseAsync<ProductDtoCouch>("e-commerce2");
            var database = client.GetDatabase<ProductDtoCouch>("e-commerce2");
            // Process each user in parallel:
            Parallel.For(0, listUserId.Count, i =>
            {
                // Build a list with 100 simulated products for the user.
                var productList = new List<ProductDtoCouch>();
                for (int j = 0; j < 100000; j++)
                {
                    var product = new ProductDtoCouch(
                        Guid.NewGuid().ToString(),
                        "Category1",
                        "Type1",
                        "Description1",
                        100,
                        10,
                        listUserId[i]
                    );
                    productList.Add(product);
                }

                // Delete existing products for the current user.
                var productsToDelete = database
                    .Where(p => p.SellerId == listUserId[i])
                    .ToList();
                foreach (ProductDtoCouch product in productsToDelete)
                {
                    database.DeleteAsync(product).Wait();
                }

                // Insert new products by iterating over the productList.
                database.CreateOrUpdateRangeAsync(productList).Wait();
            });
            client.DeleteDatabaseAsync<ProductDtoCouch>("e-commerce2");
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

            var client = new CouchClient("http://localhost:5984",
                settings => { settings.UseBasicAuthentication("admin", "admin"); });
            client.CreateDatabaseAsync<ProductDtoCouch>("e-commerce3");
            var database = client.GetDatabase<ProductDtoCouch>("e-commerce3");
            // Process each user in parallel:
            Parallel.For(0, listUserId.Count, i =>
            {
                // Build a list with 100 simulated products for the user.
                var productList = new List<ProductDtoCouch>();
                for (int j = 0; j < 800000; j++)
                {
                    var product = new ProductDtoCouch(
                        Guid.NewGuid().ToString(),
                        "Category1",
                        "Type1",
                        "Description1",
                        100,
                        10,
                        listUserId[i]
                    );
                    productList.Add(product);
                }

                // Delete existing products for the current user.
                var productsToDelete = database
                    .Where(p => p.SellerId == listUserId[i])
                    .ToList();
                foreach (ProductDtoCouch product in productsToDelete)
                {
                    database.DeleteAsync(product).Wait();
                }

                // Insert new products by iterating over the productList.
                database.CreateOrUpdateRangeAsync(productList).Wait();
            });
            client.DeleteDatabaseAsync<ProductDtoCouch>("e-commerce3");
        }
    }
}