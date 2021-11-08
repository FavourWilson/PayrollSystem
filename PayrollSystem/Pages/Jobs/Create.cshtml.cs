using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Services;

namespace PayrollSystem.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly IncomeRepository incomeRepository;

        public CreateModel(IncomeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Income Income { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Income = incomeRepository.Add(Income);

            return RedirectToPage("./Index");
        }
    }
}
