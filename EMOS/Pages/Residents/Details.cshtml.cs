﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Residents
{
    public class DetailsModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public DetailsModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        public Resident Resident { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resident = await _context.Resident.FirstOrDefaultAsync(m => m.ID == id);

            if (Resident == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
