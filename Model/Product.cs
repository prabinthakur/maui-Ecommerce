using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Second.Enum;

namespace Second.Model
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name { get; set; }
        public ProductType type { get; set; }
        public int price { get; set; }
    }
}
