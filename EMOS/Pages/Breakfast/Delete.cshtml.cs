using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Breakfast
{
    public class DeleteModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DeleteModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Breakfastmeal Breakfastmeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breakfastmeal = await _context.Breakfastmeal.FirstOrDefaultAsync(m => m.ID == id);

            if (Breakfastmeal == null)
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

            Breakfastmeal = await _context.Breakfastmeal.FindAsync(id);

            if (Breakfastmeal != null)
            {
                _context.Breakfastmeal.Remove(Breakfastmeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
