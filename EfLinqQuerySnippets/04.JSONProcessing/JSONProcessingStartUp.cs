using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfLinqQuerySnippets._04.JSONProcessing.Data;
using EfLinqQuerySnippets._04.JSONProcessing.DTOs;
using EfLinqQuerySnippets._04.JSONProcessing.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EfLinqQuerySnippets._04.JSONProcessing
{
    public class JSONProcessingStartUp
    {
        private IMapper _mapper;

        public void Run()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            _mapper = new Mapper(config);

            using (var context = new CarDealerContext())
            {

                //var json = File.ReadAllText(@"C:\_2021_Learning\DonVo.NetSnippets.Year2021\EfLinqQuerySnippets\04.JSONProcessing\Datasets\suppliers.json");
                //var json = File.ReadAllText(@"C:\_2021_Learning\DonVo.NetSnippets.Year2021\EfLinqQuerySnippets\04.JSONProcessing\Datasets\parts.json");
                var json = File.ReadAllText(@"C:\_2021_Learning\DonVo.NetSnippets.Year2021\EfLinqQuerySnippets\04.JSONProcessing\Datasets\cars.json");
                //var json = File.ReadAllText(@"C:\_2021_Learning\DonVo.NetSnippets.Year2021\EfLinqQuerySnippets\04.JSONProcessing\Datasets\customers.json");
                //var json = File.ReadAllText(@"C:\_2021_Learning\DonVo.NetSnippets.Year2021\EfLinqQuerySnippets\04.JSONProcessing\Datasets\sales.json");

                //Console.WriteLine(ImportSuppliers(context, json));
                //Console.WriteLine(ImportParts(context, json));
                //Console.WriteLine(ImportCars(context, json));
                //Console.WriteLine(ImportCustomers(context, json));
                //Console.WriteLine(ImportSales(context, json));

                //Console.WriteLine(GetLocalSuppliers(context));
                //Console.WriteLine(GetOrderedCustomers(context));
                Console.WriteLine(GetCarsFromMakeToyota(context));
            }
        }

        // 1
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        // 2
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers.Select(s => s.Id).ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).Where(p => p.SupplierId <= suppliers.Count).ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        // 3
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // 4
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        // 5
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        // 6
        public string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<ExperiencedDriverDTO>(_mapper.ConfigurationProvider)
                .ToList();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);


            return customersJson;
        }

        // 7
        public string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarToyotaDTO>(_mapper.ConfigurationProvider)
                .ToList();

            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }

        // 8
        public string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImported == false)
                .ProjectTo<NationalPartDTO>(_mapper.ConfigurationProvider)
                .ToList();

            var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersJson;
        }
    }
}
