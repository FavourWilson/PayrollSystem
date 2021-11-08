using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class Income
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public double Cost { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
