﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Lunch
{
    public class DeleteModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DeleteModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lunchmeal Lunchmeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lunchmeal = await _context.Lunchmeal.FirstOrDefaultAsync(m => m.ID == id);

            if (Lunchmeal == null)
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

            Lunchmeal = await _context.Lunchmeal.FindAsync(id);

            if (Lunchmeal != null)
            {
                _context.Lunchmeal.Remove(Lunchmeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
