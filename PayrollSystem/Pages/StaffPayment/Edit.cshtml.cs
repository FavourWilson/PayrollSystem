using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace PayrollSystem.Pages.StaffPayment
{
    public class EditModel : PageModel
    {
        
       

        public EditModel(ISalary salaries, IEmployeeRepository EmployeeRepository)
        {
            Salaries = salaries;
            this.EmployeeRepository = EmployeeRepository;
            
        }

        [BindProperty]
        public Salary Salary { get; set; }
        public IEmployeeRepository EmployeeRepository { get; }
        public ISalary Salaries { get; }

        public IActionResult OnGet(int id)
        {
          
            Salary = Salaries.GetSalary(id);

            if (Salary == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            try
            {
                Salary = Salaries.Update(id, Salary);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Salary == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }


    }
}
