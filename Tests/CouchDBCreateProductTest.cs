// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using CouchDB.Driver;
// using MDBMS___E_COMMERCE_PLATFORM.Form.Shop;
// using MDBMS___E_COMMERCE_PLATFORM.Repository.Entity;
// using MongoDB.Driver;
// using NUnit.Framework;
//
// namespace MDBMS___E_COMMERCE_PLATFORM.Tests
// {
//     public class CouchDbCreateProductTest
//     {
//         [Test]
//         public void Given_5_user_100_row_for_create_product()
//         {
//             // Arrange
//             List<string> listUserId = new List<string>();
//
//             var user1 = new Storage("toantu03@gmail.com", new MongoClient("mongodb://localhost:27017"));
//             var user2 = new Storage("emma.gadget@gmail.com", new MongoClient("mongodb://localhost:27017"));
//             var user3 = new Storage("sophia.style@gmail.com", new MongoClient("mongodb://localhost:27017"));
//             var user4 = new Storage("oliver.books@gmail.com", new MongoClient("mongodb://localhost:27017"));
//             var user5 = new Storage("mia.decor@gmail.com", new MongoClient("mongodb://localhost:27017"));
//
//             var id1 = user1.ExtractUserId("toantu03@gmail.com");
//             var id2 = user2.ExtractUserId("emma.gadget@gmail.com");
//             var id3 = user3.ExtractUserId("sophia.style@gmail.com");
//             var id4 = user4.ExtractUserId("oliver.books@gmail.com");
//             var id5 = user5.ExtractUserId("mia.decor@gmail.com");
//
//             listUserId.Add(id1);
//             listUserId.Add(id2);
//             listUserId.Add(id3);
//             listUserId.Add(id4);
//             listUserId.Add(id5);
//
//             var client = new CouchClient("http://localhost:5984");
//
//             // Process each user in parallel:
//             Parallel.For(0, listUserId.Count, (int i) =>
//             {
//                 // Create or access the database for the current operation.
//                 var database = client.CreateDatabaseAsync<ProductDtoCouch>("e-commerce")
//                                      .GetAwaiter().GetResult();
//
//                 // Build a list with 100 simulated products for the user.
//                 var productList = new List<ProductDtoCouch>();
//                 for (int j = 0; j < 100; j++)
//                 {
//                     var product = new ProductDtoCouch(
//                         Guid.NewGuid().ToString(),
//                         "Category1",
//                         "Type1",
//                         "Description1",
//                         100,
//                         10,
//                         "",
//                         listUserId[i]
//                     );
//                     productList.Add(product);
//                 }
//
//                 // Delete existing products for the current user.
//                 var query = "{\"selector\": {\"SellerId\": \"" + listUserId[i] + "\"}}";
//                 var productsToDelete = database.FindAsync(query).GetAwaiter().GetResult();
//                 if (productsToDelete != null)
//                 {
//                     foreach (ProductDtoCouch product in productsToDelete)
//                     {
//                         database.RemoveAsync(product).Wait();
//                     }
//                 }
//
//                 // Insert new products by iterating over the productList.
//                 foreach (var product in productList)
//                 {
//                     database.AddAsync(product).Wait();
//                 }
//             });
//         }
//     }
// }
