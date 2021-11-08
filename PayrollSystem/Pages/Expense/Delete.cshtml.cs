using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace PayrollSystem.Pages.Expense
{
    public class DeleteModel : PageModel
    {
        private readonly Services.AppDbContext _context;

        public DeleteModel(Services.AppDbContext context, IExpensesRepository expensesRepository)
        {
            _context = context;
            ExpensesRepository = expensesRepository;
        }

        [BindProperty]
        public Expenses Expenses { get; set; }
        public IExpensesRepository ExpensesRepository { get; }

        public IActionResult OnGet(int id)
        {
            
            Expenses = ExpensesRepository.GetExpense(id);

            if (Expenses == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {

            Expenses deleteExpenses = ExpensesRepository.DeleteExpense(Expenses.Id);
            if (deleteExpenses != null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
