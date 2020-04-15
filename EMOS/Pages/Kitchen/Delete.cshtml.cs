using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Kitchen
{
    public class DeleteModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DeleteModel(EMOS.Models.EMOSContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kitchendepart = await _context.Kitchendepart.FindAsync(id);

            if (Kitchendepart != null)
            {
                _context.Kitchendepart.Remove(Kitchendepart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
