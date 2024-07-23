using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Second.Model;
using Second.Utils;
using System.Diagnostics;

namespace Second.Service
{
    public class OrderService
    {
        public static async Task<List<Order>> GetAllAsync()
        {
            string appOrderFilePath = Filepath.GetAppOrdersFilePath();
            if (!File.Exists(appOrderFilePath))
            {
                return new List<Order>();
            }

            var json = await File.ReadAllTextAsync(appOrderFilePath);
            // Debug.WriteLine(json);

            return JsonSerializer.Deserialize<List<Order>>(json);
        }

        public static async Task AddOrderAsync(Order newOrder)
        {
            try
            {
                List<Order> existingOrders = await GetAllAsync();
                existingOrders.Add(newOrder);

                Debug.WriteLine("Get all");

                string appDataDirectoryPath = Filepath.GetAppDirectoryPath();
                string appOrderFilePath = Filepath.GetAppOrdersFilePath();

                if (!Directory.Exists(appDataDirectoryPath))
                {
                    Directory.CreateDirectory(appDataDirectoryPath);
                }
                var json = JsonSerializer.Serialize(existingOrders);
                Debug.WriteLine(json);
                await File.WriteAllTextAsync(appOrderFilePath, json);
                Debug.WriteLine("Get After add");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task<List<Order>> GetOrdersByUserNumberAsync(string userNumber)
        {
            List<Order> allOrders = await GetAllAsync();
            List<Order> userOrders = allOrders.Where(order => order.Number == userNumber).ToList();
            return userOrders;
        }
    }
}
