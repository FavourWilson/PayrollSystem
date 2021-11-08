using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace PayrollSystem.Pages.StaffPayment
{
    public class IndexModel : PageModel
    {
        
        private readonly ISalary salary;

        public IndexModel(ISalary salary, IEmployeeRepository employeeRepository)
        {
           
            this.salary = salary;
            EmployeeRepository = employeeRepository;
        }

        [BindProperty]
        public IEnumerable<Salary> Salary { get;set; }
        public IEmployeeRepository EmployeeRepository { get; }

        public void OnGet()
        {

            Salary = salary.GetSalaries();
        }
    }
}
