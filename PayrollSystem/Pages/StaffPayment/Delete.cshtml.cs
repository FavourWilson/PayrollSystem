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
    public class DeleteModel : PageModel
    {
        private readonly Services.AppDbContext _context;
        private readonly ISalary salary;

        public DeleteModel(ISalary salary)
        {
           
            this.salary = salary;
        }

        [BindProperty]
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

        public IActionResult OnPost(int id)
        {
            

            Salary salaries = salary.Delete(id);    

            if (Salary != null)
            {
                Salary = salary.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
