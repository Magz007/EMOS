using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Dinner
{
    public class DeleteModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DeleteModel(EMOS.Models.EMOSContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinnermeal = await _context.Dinnermeal.FindAsync(id);

            if (Dinnermeal != null)
            {
                _context.Dinnermeal.Remove(Dinnermeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
