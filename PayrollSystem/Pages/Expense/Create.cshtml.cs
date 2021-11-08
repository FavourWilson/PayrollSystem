using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace PayrollSystem.Pages.Expense
{
    public class CreateModel : PageModel
    {
        private readonly IExpensesRepository expensesRepository;
        [BindProperty]
        public Expenses Expenses { get; set; }
        public IEmployeeRepository EmployeeRepository { get; }
        public CreateModel(IExpensesRepository expensesRepository, IEmployeeRepository employeeRepository)
        {
            this.expensesRepository = expensesRepository;
            EmployeeRepository = employeeRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Expenses != null)
            {
                Expenses = expensesRepository.Add(Expenses);
            }
            return RedirectToPage("./Index");

        }
    }
}
