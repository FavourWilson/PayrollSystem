using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee_Expenses
    {
        public int Id{ get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ExpensesId { get; set; }
        public Expenses Expenses { get; set; }
    }
}
