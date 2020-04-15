﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Lunch
{
    public class EditModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public EditModel(EMOS.Models.EMOSContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lunchmeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunchmealExists(Lunchmeal.ID))
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

        private bool LunchmealExists(int id)
        {
            return _context.Lunchmeal.Any(e => e.ID == id);
        }
    }
}
