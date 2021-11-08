using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string Expense { get; set; }
        public double AmountSpent { get; set; }
        public DateTime DateSpent { get; set; }
        public Dept Department { get; set; }
        public List<Employee> Employee { get; set; }

        public List<Employee_Expenses> Employee_Expenses { get; set; }
    }
}
