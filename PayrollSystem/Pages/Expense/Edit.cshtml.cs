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

namespace PayrollSystem.Pages.Expense
{
    public class EditModel : PageModel
    {
        private readonly IExpensesRepository expensesRepository;

        public EditModel(IEmployeeRepository employeeRepository, IExpensesRepository expensesRepository)
        {
            EmployeeRepository = employeeRepository;
            this.expensesRepository = expensesRepository;
        }

        [BindProperty]
        public Expenses Expenses { get; set; }
        public IEmployeeRepository EmployeeRepository { get; }

        public IActionResult OnGet(int id)
        {

            Expenses = expensesRepository.GetExpense(id);

            if (Expenses == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            try
            {
                Expenses = expensesRepository.Update(Expenses);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Expenses == null)
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
