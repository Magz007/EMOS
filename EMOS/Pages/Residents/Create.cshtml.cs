﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMOS.Models;

namespace EMOS.Pages.Residents
{
    public class CreateModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public CreateModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Resident Resident { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Resident.Add(Resident);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}