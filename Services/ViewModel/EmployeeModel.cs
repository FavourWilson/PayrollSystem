using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class EmployeeModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employes { get; set; }
    }
}
