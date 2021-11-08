using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Salary
    {
        public int Id { get; set; }
        public List<Employee> Employee { get; set; }

        public string EmployeeName { get; set; }
        public Dept Department { get; set; }
        public DateTime DatePaid { get; set; }
        public double AmountPaid { get; set; }
    }
}
