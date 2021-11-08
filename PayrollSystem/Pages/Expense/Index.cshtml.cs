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
    public class IndexModel : PageModel
    {
        private readonly Services.AppDbContext _context;
        private readonly IExpensesRepository expensesRepository;

        public IndexModel(IExpensesRepository expensesRepository)
        {
            
            this.expensesRepository = expensesRepository;
        }

        public IEnumerable<Expenses> Expenses { get;set; }

        public void OnGet()
        {
            Expenses = expensesRepository.GetExpenses();
        }
    }
}
