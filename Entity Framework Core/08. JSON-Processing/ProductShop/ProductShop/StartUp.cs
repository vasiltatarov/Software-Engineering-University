using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            InitializeMapper();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //ImportUsers(db);
            //ImportProducts(db);
            //ImportCategories(db);
            //ImportCategoriesAndProducts(db);

            //ExportSuccessfullySoldProducts(db);

            ExportUsersAndProducts(db);
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        //Query 8. Export Users and Products
        private static void ExportUsersAndProducts(ProductShopContext db)
        {
            var result = GetUsersWithProducts(db);

            if (!Directory.Exists("../../../Result"))
            {
                Directory.CreateDirectory("../../../Result");
            }

            File.WriteAllText("../../../Result/users-and-products.json", result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                                .Select(p => new
                                {
                                    name = p.Name,
                                    price = p.Price,
                                })
                                .ToArray()
                    },
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var result = new
            {
                usersCount = users.Length,
                users = users,
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(result, settings);

            return json;
        }

        //Query 5. Export Products in Range
        private static void ExportProductsInRange(ProductShopContext db)
        {
            var result = GetProductsInRange(db);
            File.WriteAllText("../../../products-in-range.json", result);
        }

        //Query 6. Export Successfully Sold Products
        private static void ExportSuccessfullySoldProducts(ProductShopContext db)
        {
            var result = GetSoldProducts(db);

            if (!Directory.Exists("../../../Result"))
            {
                Directory.CreateDirectory("../../../Result");
            }

            File.WriteAllText("../../../Result/users-sold-products.json", result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            //Without Auto 
            //var users = context.Users
            //    .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
            //    .Select(x => new
            //    {
            //        firstName = x.FirstName,
            //        lastName = x.LastName,
            //        soldProducts = x.ProductsSold
            //            .Where(p => p.Buyer != null)
            //            .Select(p => new
            //            {
            //                name = p.Name,
            //                price = p.Price,
            //                buyerFirstName = p.Buyer.FirstName,
            //                buyerLastName = p.Buyer.LastName,
            //            })
            //            .ToList()
            //    })
            //    .OrderBy(x => x.lastName)
            //    .ThenBy(x => x.firstName)
            //    .ToList();

            //With AutoMapper
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ProjectTo<UserWithSoldProductDTO>()
                .ToList();

            var jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonUsers;
        }

        //07. Export Categories By Products Count
        private static void ExportCategoriesByProductsCount(ProductShopContext db)
        {
            var result = GetCategoriesByProductsCount(db);

            if (!Directory.Exists("../../../Result"))
            {
                Directory.CreateDirectory("../../../Result");
            }

            File.WriteAllText("../../../Result/categories-by-products.json", result);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2"),
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName,
                })
                .OrderBy(x => x.price)
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonProducts;
        }

        //Query 4. Import Categories
        private static void ImportCategories(ProductShopContext db)
        {
            var categoriesReaderJson = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(db, categoriesReaderJson));
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoriesReaderJson = JsonConvert.DeserializeObject<Category[]>(inputJson, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var insertedCount = 0;
            foreach (var category in categoriesReaderJson)
            {
                if (category.Name != null)
                {
                    context.Categories.Add(category);
                    insertedCount++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {insertedCount}";
        }

        //Query 5. Import Categories and Products
        private static void ImportCategoriesAndProducts(ProductShopContext db)
        {
            var categoriesAndProductsReaderJson = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(db, categoriesAndProductsReaderJson));
        }

        public static string ImportCategoryProducts(ProductShopContext db, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            db.CategoryProducts.AddRange(categoryProducts);
            db.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //Query 2. Import Users
        private static void ImportUsers(ProductShopContext db)
        {
            var usersReaderJson = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(db, usersReaderJson));
        }

        //Query 3. Import Products
        private static void ImportProducts(ProductShopContext db)
        {
            var productsReaderJson = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(db, productsReaderJson));
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}