using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin
{
    public class AddSocialNetworksModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public AddSocialNetworksModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            else
            {
                ViewData["username"] = HttpContext.Session.GetString("Name");
            }
            return Page();
        }

        [BindProperty]
        public SocialNetworks SocialNetworks { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tbl_SocialNetworks.Add(SocialNetworks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ShowSocialNetworks");
        }
    }
}
