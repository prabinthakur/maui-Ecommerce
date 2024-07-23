using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Second.Enum;

namespace Second.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
