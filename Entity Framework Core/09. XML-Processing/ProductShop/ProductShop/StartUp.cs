using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            InitializeAutoMapper();
            //DeleteAndCreateDatabase(db);

            //P01ImportUsers(db);
            //P02ImportProducts(db);
            //P03ImportCategories(db);
            //P04ImportCategoriesAndProducts(db);

            //P05
            //var result = GetProductsInRange(db);
            //File.WriteAllText("../../../products-in-range.xml", result);

            //P06
            //var result = GetSoldProducts(db);
            //File.WriteAllText("../../../users-sold-products.xml", result);

            //P07
            //var result = GetCategoriesByProductsCount(db);
            //File.WriteAllText("../../../categories-by-products.xml", result);

            //P08
            var result = GetUsersWithProducts(db);
            File.WriteAllText("../../../users-and-products.xml", result);
        }
        
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()//
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(x => new UserAndProductsDTO()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductsDTO()
                    {
                        Count = x.ProductsSold.Count(p => p.Buyer != null),
                        Products = x.ProductsSold
                            .ToArray()//
                            .Where(ps => ps.Buyer != null)
                            .Select(p => new ProductSoldDTO()
                            {
                                Name = p.Name,
                                Price = p.Price,
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray(),
                    }
                })
                .ToArray();

            var usersAndProducts = new UserWithProductsDTO()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                Users = users,
            };

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var xmlSerializer = new XmlSerializer(typeof(UserWithProductsDTO),
                new XmlRootAttribute("Users"));

            xmlSerializer.Serialize(new StringWriter(sb), usersAndProducts, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoryByProductsCountDTO()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CategoryByProductsCountDTO[]),
                new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .Select(x => new GetUserSoldProductDTO()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new UserProductDTO()
                        {
                            Name = p.Name,
                            Price = p.Price,
                        })
                        .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetUserSoldProductDTO[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ProductInRangeDTO()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ProductInRangeDTO[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static void P04ImportCategoriesAndProducts(ProductShopContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var result = ImportCategoryProducts(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductDto = (CategoryProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var dto in categoryProductDto)
            {
                categoryProducts.Add(new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId,
                });
            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static void P03ImportCategories(ProductShopContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/categories.xml");
            var result = ImportCategories(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryDTO[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (CategoryDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            //var categories = Mapper.Map<Category[]>(categoriesDto);

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name != null)
                {
                    categories.Add(new Category()
                    {
                        Name = categoryDto.Name,
                    });
                }
            }

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static void P02ImportProducts(ProductShopContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/products.xml");
            var result = ImportProducts(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductDTO[]), new XmlRootAttribute("Products"));

            var productDto = (ProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var dto in productDto)
            {
                products.Add(new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId,
                });
            }

            //var products = Mapper.Map<Product[]>(productDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        private static void P01ImportUsers(ProductShopContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(db, xml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //var xmlDocument = XDocument.Parse(inputXml);

            //var users = xmlDocument.Root
            //    .Elements()
            //    .Select(x => new User()
            //    {
            //        FirstName = x.Element("firstName").Value,
            //        LastName = x.Element("lastName").Value,
            //        //Age = int.Parse(x.Element("age").Value)
            //        Age = x.Element("age").Value == null ? (int?)null : int.Parse(x.Element("age").Value)
            //    })
            //    .ToList();

            //var xmlSerializer = new XmlSerializer(typeof(User), new XmlRootAttribute("Users"));
            //var users = (User[])xmlSerializer.Deserialize(File.OpenRead("../../../Datasets/users.xml"));

            var xmlSerializer = new XmlSerializer(typeof(Dtos.Import.UserDTO[]), new XmlRootAttribute("Users"));

            var usersDto = (Dtos.Import.UserDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = Mapper.Map<Models.User[]>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        private static void DeleteAndCreateDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cnf =>
            {
                cnf.AddProfile<ProductShopProfile>();
            });
        }
    }
}