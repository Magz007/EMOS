﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMOS.Pages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Username.Equals("abc") && Password.Equals("123"))
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Welcome");
            }
            else
            {
                Message = "Invalid";
                return Page();
            }
        }
    }

}
