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
    public class DetailsModel : PageModel
    {
        private readonly Services.AppDbContext _context;
        private readonly IExpensesRepository expensesRepository;

        public DetailsModel(IExpensesRepository expensesRepository)
        {
            this.expensesRepository = expensesRepository;
        }

        public Expenses Expenses { get; set; }

        public IActionResult OnGet(int id)
        {

            Expenses = expensesRepository.GetExpense(id);

            if (Expenses == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
