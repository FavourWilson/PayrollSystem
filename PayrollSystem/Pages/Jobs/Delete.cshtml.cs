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
    public class DeleteModel : PageModel
    {
        private readonly Services.AppDbContext _context;

        public DeleteModel(Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.incomes.FirstOrDefaultAsync(m => m.Id == id);

            if (Income == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.incomes.FindAsync(id);

            if (Income != null)
            {
                _context.incomes.Remove(Income);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
