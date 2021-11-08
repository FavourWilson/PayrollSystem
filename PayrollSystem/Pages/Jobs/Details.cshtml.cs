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
    public class DetailsModel : PageModel
    {
        private readonly Services.AppDbContext _context;
        private readonly IncomeRepository incomeRepository;

        public DetailsModel(IncomeRepository incomeRepository)
        {
            
            this.incomeRepository = incomeRepository;
        }

        public Income Income { get; set; }

        public IActionResult OnGet(int id)
        {
            Income = incomeRepository.GetIncome(id);
            if (Income == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
