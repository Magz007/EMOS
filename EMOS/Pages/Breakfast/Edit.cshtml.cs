using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Breakfast
{
    public class EditModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public EditModel(EMOS.Models.EMOSContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Breakfastmeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreakfastmealExists(Breakfastmeal.ID))
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

        private bool BreakfastmealExists(int id)
        {
            return _context.Breakfastmeal.Any(e => e.ID == id);
        }
    }
}
