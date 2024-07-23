using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Utils
{
    public class Filepath
    {
        public static string GetAppDirectoryPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Split("bin")[0], "wwwroot\\Files");
        }

        public static string GetAppProductsFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "products.json");
        }

        public static string GetAppOrdersFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "orders.json");
        }

        public static string GetAppMememberFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "members.json");
        }

    }
}
