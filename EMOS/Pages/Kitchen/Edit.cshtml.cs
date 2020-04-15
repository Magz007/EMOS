using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Kitchen
{
    public class EditModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public EditModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kitchendepart Kitchendepart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kitchendepart = await _context.Kitchendepart.FirstOrDefaultAsync(m => m.ID == id);

            if (Kitchendepart == null)
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

            _context.Attach(Kitchendepart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitchendepartExists(Kitchendepart.ID))
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

        private bool KitchendepartExists(int id)
        {
            return _context.Kitchendepart.Any(e => e.ID == id);
        }
    }
}
