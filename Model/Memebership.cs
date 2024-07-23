using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Model
{
    public class Memebership
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Number { get; set; }
        public DateOnly JoinedDate { get; set; }
    }
}
