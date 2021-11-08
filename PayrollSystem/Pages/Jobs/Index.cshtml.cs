using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace PayrollSystem.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly Services.AppDbContext _context;
        private readonly IncomeRepository incomeRepository;

        public IndexModel(IncomeRepository incomeRepository)
        {
           
            this.incomeRepository = incomeRepository;
        }

        public IEnumerable<Income> Income { get;set; }

        public void OnGet()
        {
            Income = incomeRepository.GetIncomes();
        }
    }
}
