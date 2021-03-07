using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Export.GetCarsFromMakeBmw;
using CarDealer.Dtos.Export.GetCarsWithDistance;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static Mapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            InitializeMapper();

            //DeleteAndCreateDatabase(db);

            //ImportSuppliersData(db);
            //ImportPartsData(db);
            //ImportCarsData(db);
            //ImportCustomersData(db);
            //ImportSalesData(db);

            //14. Export Cars With Distance
            //var result = GetCarsWithDistance(db);
            //File.WriteAllText("../../../cars.xml", result);

            //16. Export Local Suppliers
            //var result = GetLocalSuppliers(db);
            //File.WriteAllText("../../../local-suppliers.xml", result);

            //17. Export Cars With Their List Of Parts
            var result = GetCarsWithTheirListOfParts(db);
            File.WriteAllText("../../../cars-and-parts.xml", result);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var suppliers = context.Cars
                .Select(x => new GetCarDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars
                        .Select(p => new CarPartsDTO()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price,
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(GetCarDTO[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new GetLocalSupplierDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count,
                })
                .ToArray();

            //var suppliers = context.Suppliers
            //    .Where(x => x.IsImporter == false)
            //    .ProjectTo<GetLocalSupplierDTO>(mapper.ConfigurationProvider)
            //    .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(GetLocalSupplierDTO[]),
                new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarBMWDTO()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(CarBMWDTO[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), bmwCars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new CarWithDistanceDTO()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            //With AutoMapper
            //var cars = context.Cars
            //    .Where(x => x.TravelledDistance > 2000000)
            //    .OrderBy(x => x.Make)
            //    .ThenBy(x => x.Model)
            //    .Take(10)
            //    .ProjectTo<CarWithDistanceDTO>(mapper.ConfigurationProvider)
            //    .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(CarWithDistanceDTO[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static void ImportSalesData(CarDealerContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/sales.xml");
            var result = ImportSales(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SaleDTO[]), new XmlRootAttribute("Sales"));

            var salesDtos = (SaleDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var dto in salesDtos)
            {
                if (context.Cars.Find(dto.CarId) == null)
                {
                    continue;
                }

                sales.Add(new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount,
                });
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        public static void ImportCustomersData(CarDealerContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/customers.xml");
            var result = ImportCustomers(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("Customers"));

            var customerDtos = (CustomerDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var dto in customerDtos)
            {
                customers.Add(new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver,
                });
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static void ImportCarsData(CarDealerContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/cars.xml");
            var result = ImportCars(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarDTO[]), new XmlRootAttribute("Cars"));

            var carDtos = (CarDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var carCounter = 0;

            foreach (var carDto in carDtos)
            {
                var parts = carDto.Parts.Select(x => x.PartId).Distinct().ToArray();

                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                carCounter++;
                context.Cars.Add(car);

                foreach (var partId in parts)
                {
                    if (context.Parts.Find(partId) == null)
                    {
                        continue;
                    }

                    var partCar = new PartCar()
                    {
                        Car = car,
                        PartId = partId,
                    };

                    context.PartCars.Add(partCar);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carCounter}";
        }

        public static void ImportPartsData(CarDealerContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/parts.xml");
            var result = ImportParts(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartDTO[]), new XmlRootAttribute("Parts"));

            var partsDtos = (PartDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var dto in partsDtos)
            {
                if (context.Suppliers.Find(dto.SupplierId) == null)
                {
                    continue;
                }

                parts.Add(new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId,
                });
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        private static void InitializeMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(configuration);
        }

        //P01
        public static void ImportSuppliersData(CarDealerContext db)
        {
            var xml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var result = ImportSuppliers(db, xml);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierDTO[]), new XmlRootAttribute("Suppliers"));

            var suppliersDtos = (SupplierDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            //var suppliers = mapper.Map<Supplier[]>(suppliersDtos);

            var suppliers = new List<Supplier>();

            foreach (var dto in suppliersDtos)
            {
                suppliers.Add(new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter,
                });
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        private static void DeleteAndCreateDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
