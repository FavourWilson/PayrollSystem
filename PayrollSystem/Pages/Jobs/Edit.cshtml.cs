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

namespace PayrollSystem.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly Services.AppDbContext _context;
        private readonly IncomeRepository incomeRepository;

        public EditModel(IncomeRepository incomeRepository)
        {
           
            this.incomeRepository = incomeRepository;
        }

        [BindProperty]
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
                Income = incomeRepository.Update(Income);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Income == null)
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
