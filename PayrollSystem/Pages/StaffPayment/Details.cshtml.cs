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
    public class DetailsModel : PageModel
    {
        
        private readonly ISalary salary;

        public DetailsModel(ISalary salary)
        {
            this.salary = salary;
        }

        public Salary Salary { get; set; }

        public IActionResult OnGet(int id)
        {

            Salary = salary.GetSalary(id);

            if (Salary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
