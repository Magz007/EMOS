using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Emploee
{
    public class DetailsModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DetailsModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        public Employees Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees.FirstOrDefaultAsync(m => m.ID == id);

            if (Employees == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
