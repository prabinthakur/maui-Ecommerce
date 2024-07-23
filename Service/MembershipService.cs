using Second.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Second.Utils;
using System.Diagnostics;

namespace Second.Service
{
    public class MembershipService
    {
        public static async Task<List<Memebership>> GetAllAsync()
        {
            string appMemebershipFilePath = Filepath.GetAppMememberFilePath();
            if (!File.Exists(appMemebershipFilePath))
            {
                return new List<Memebership>();
            }

            var json = await File.ReadAllTextAsync(appMemebershipFilePath);
            // Debug.WriteLine(json);

            return JsonSerializer.Deserialize<List<Memebership>>(json);
        }

        public static async Task AddMemember(IEnumerable<Memebership> newMemember)
        {
            try
            {
                List<Memebership> existingMemember = await GetAllAsync();
                existingMemember.AddRange(newMemember);

                Debug.WriteLine("Get all");

                string appDataDirectoryPath = Filepath.GetAppDirectoryPath();
                string appMemebershipFilePath = Filepath.GetAppMememberFilePath();

                if (!Directory.Exists(appDataDirectoryPath))
                {
                    Directory.CreateDirectory(appDataDirectoryPath);
                }
                var json = JsonSerializer.Serialize(existingMemember);
                await File.WriteAllTextAsync(appMemebershipFilePath, json);
                Debug.WriteLine("Get After add");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

    }

}
