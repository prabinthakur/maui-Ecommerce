using Second.Components;
using Second.Model;
using Second.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Second.Service
{
    public class ProductService
    {
        public static async Task<List<Product>> GetAllAsync()
        {
            string appProductFilePath = Filepath.GetAppProductsFilePath();
            if (!File.Exists(appProductFilePath))
            {
                return new List<Product>();
            }

            var json = await File.ReadAllTextAsync(appProductFilePath);
            // Debug.WriteLine(json);

            return JsonSerializer.Deserialize<List<Product>>(json);
        }

        public static async Task SerializeProductsAsync(IEnumerable<Product> newProducts)
        {
            try { 
                List<Product> existingProducts = await GetAllAsync();
                existingProducts.AddRange(newProducts);

                Debug.WriteLine("Get all");

                string appDataDirectoryPath = Filepath.GetAppDirectoryPath();
                string appProductFilePath = Filepath.GetAppProductsFilePath();

                if (!Directory.Exists(appDataDirectoryPath))
                {
                    Directory.CreateDirectory(appDataDirectoryPath);
                }
                var json = JsonSerializer.Serialize(existingProducts);
                await File.WriteAllTextAsync(appProductFilePath, json);
                Debug.WriteLine("Get After add");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public static async Task<List<Product>> DeleteAsync(Guid id)
        {
            try
            {
                string appProductFilePath = Filepath.GetAppProductsFilePath();
                var json = await File.ReadAllTextAsync(appProductFilePath);
                List<Product> items = JsonSerializer.Deserialize<List<Product>>(json);

                Debug.WriteLine("-------------------------------------------------------------");
                Debug.WriteLine(json);

                Product itemToRemove = items.FirstOrDefault(x => x.Id == id);
                Debug.WriteLine("to remove ----------- ");
                Debug.WriteLine(itemToRemove);

                if (itemToRemove == null)
                {
                    throw new Exception("Item not found.");
                }
                items.Remove(itemToRemove);
                var updatedJson = JsonSerializer.Serialize(items);
                await File.WriteAllTextAsync(appProductFilePath, updatedJson);
                return await GetAllAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        public static async Task<List<Product>> UpdateAsync(Guid id, Product updatedProduct)
        {
            string appProductFilePath = Filepath.GetAppProductsFilePath();
            var json = await File.ReadAllTextAsync(appProductFilePath);
            List<Product> items = JsonSerializer.Deserialize<List<Product>>(json);

            Debug.WriteLine("-------------------------------------------------------------");
            Debug.WriteLine(json);

            Product itemToUpdate = items.FirstOrDefault(x => x.Id == id);

            if (itemToUpdate == null)
            {
                throw new Exception("Item not found.");
            }
            itemToUpdate.name = updatedProduct.name;
            itemToUpdate.price = updatedProduct.price;
            itemToUpdate.type = updatedProduct.type;

            var updatedJson = JsonSerializer.Serialize(items);

            await File.WriteAllTextAsync(appProductFilePath, updatedJson);

            return items;
        }


    }
}
