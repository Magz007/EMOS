using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Dinner
{
    public class EditModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public EditModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dinnermeal Dinnermeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinnermeal = await _context.Dinnermeal.FirstOrDefaultAsync(m => m.ID == id);

            if (Dinnermeal == null)
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

            _context.Attach(Dinnermeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinnermealExists(Dinnermeal.ID))
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

        private bool DinnermealExists(int id)
        {
            return _context.Dinnermeal.Any(e => e.ID == id);
        }
    }
}
