﻿using Microsoft.Extensions.Logging;
using OTLOB_7aln_Core.Entities;
using System.Text.Json;

namespace OTLOB_7aln_Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(ILoggerFactory Ilogger, StoreContext context)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../OTLOB_7aln_Repository/DataSeed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var brand in brands)
                    {
                        await context.ProductBrands.AddAsync(brand);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = Ilogger.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
            try
            {
                if (!context.ProductTypes.Any())
                {
                    var typessData = File.ReadAllText("../OTLOB_7aln_Repository/DataSeed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typessData);
                    foreach (var type in types)
                    {
                        await context.ProductTypes.AddAsync(type);
                    }
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                var logger = Ilogger.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
            try
            {
                if (!context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("../OTLOB_7aln_Repository/DataSeed/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    foreach (var Product in Products)
                    {
                        await context.Products.AddAsync(Product);
                    }
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                var logger = Ilogger.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }

    }
}
