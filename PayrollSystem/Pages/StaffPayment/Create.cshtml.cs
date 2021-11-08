using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace PayrollSystem.Pages.StaffPayment
{
    public class CreateModel : PageModel
    {
      

        [BindProperty]
        public Salary Salary { get; set; }
        public ISalary Salaries { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public CreateModel(ISalary salaries, IEmployeeRepository employeeRepository )
        {
            
            Salaries = salaries;
            EmployeeRepository = employeeRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Salary = Salaries.Add(Salary);
            return RedirectToPage("./Index");
        }
    }
}
