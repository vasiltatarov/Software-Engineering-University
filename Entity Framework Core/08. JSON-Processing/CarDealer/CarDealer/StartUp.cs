using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Car;
using CarDealer.DTO.Supplier;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            InitializeMapper();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //ImportSuppliersTable(db);
            //ImportPartsTable(db);
            //ImportCarsTable(db);
            //ImportCustomersTable(db);
            //ImportSalesTable(db);

            // 13 Export Ordered Customers
            //var result = GetOrderedCustomers(db);
            //File.WriteAllText("../../../ordered-customers.json", result);

            // 14 Export Cars from Make Toyota
            //var result = GetCarsFromMakeToyota(db);

            //if (!Directory.Exists("../../../Result"))
            //{
            //    Directory.CreateDirectory("../../../Result");
            //}
            //File.WriteAllText("../../../Result/toyota-cars.json", result);

            // 15. Export Local Suppliers
            //var result = GetLocalSuppliers(db);
            //File.WriteAllText("../../../Result/local-suppliers.json", result);

            // 16 Export Cars with Their List of Parts
            //var result = GetCarsWithTheirListOfParts(db);
            //File.WriteAllText("../../../Result/cars-and-parts.json", result);

            // 17. Export Total Sales by Customer
            //var result = GetTotalSalesByCustomer(db);
            //File.WriteAllText("../../../Result/customers-total-sales.json", result);

            // 18. Export Sales with Applied Discount
            var result = GetSalesWithAppliedDiscount(db);
            File.WriteAllText("../../../Result/sales-discounts.json", result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Discount != 0
                        ? x.Car.PartCars.Sum(p => p.Part.Price) - (x.Car.PartCars.Sum(p => p.Part.Price) * (x.Discount / 100))
                        : x.Car.PartCars.Sum(p => p.Part.Price)).ToString("F2"),
                })
                .ToList();

            var result = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price)),
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //var cars = context.Cars
            //    .Select(x => new
            //    {
            //        car = new
            //        {
            //            Make = x.Make,
            //            Model = x.Model,
            //            TravelledDistance = x.TravelledDistance,
            //        },
            //        parts = x.PartCars
            //            .Select(p => new
            //            {
            //                Name = p.Part.Name,
            //                Price = p.Part.Price.ToString("F2"),
            //            })
            //            .ToList(),
            //    })
            //    .ToList();

            var cars = context.Cars
                .ProjectTo<CarWithPartsDTO>()
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return result;
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cnf =>
            {
                cnf.AddProfile<CarDealerProfile>();
            });
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //var suppliers = context.Suppliers
            //    .Where(x => x.IsImporter == false)
            //    .Select(x => new
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        PartsCount = x.Parts.Count,
            //    })
            //    .ToList();

            // With AutoMapper
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<LocalSupplierDTO>()
                .ToList();

            var result = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        public static void ImportSalesTable(CarDealerContext db)
        {
            var inputJson = File.ReadAllText("../../../Datasets/sales.json");

            var result = ImportSales(db, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static void ImportCustomersTable(CarDealerContext db)
        {
            var inputJson = File.ReadAllText("../../../Datasets/customers.json");

            var result = ImportCustomers(db, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static void ImportCarsTable(CarDealerContext db)
        {
            var inputJson = File.ReadAllText("../../../Datasets/cars.json");

            var result = ImportCars(db, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            foreach (var car in cars)
            {
                foreach (var partId in car.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static void ImportPartsTable(CarDealerContext db)
        {
            var inputJson = File.ReadAllText("../../../Datasets/parts.json");

            var result = ImportParts(db, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            var insertedPartsCount = 0;
            foreach (var part in parts)
            {
                if (context.Suppliers.Find(part.SupplierId) != null)
                {
                    context.Parts.Add(part);
                    insertedPartsCount++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {insertedPartsCount}.";
        }

        public static void ImportSuppliersTable(CarDealerContext db)
        {
            var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");

            var result = ImportSuppliers(db, inputJson);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }
    }
}