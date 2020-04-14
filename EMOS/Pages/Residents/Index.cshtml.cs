using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Pages.Residents
{
    public class IndexModel : PageModel
    {
        private readonly EMOS.Models.EMOSContext _context;

        public IndexModel(EMOS.Models.EMOSContext context)
        {
            _context = context;
        }

        public IList<Resident> Resident { get;set; }

        public async Task OnGetAsync()
        {
            Resident = await _context.Resident.ToListAsync();
        }
    }
}
