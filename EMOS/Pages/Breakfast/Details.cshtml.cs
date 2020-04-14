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
    public class DetailsModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DetailsModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

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
    }
}
