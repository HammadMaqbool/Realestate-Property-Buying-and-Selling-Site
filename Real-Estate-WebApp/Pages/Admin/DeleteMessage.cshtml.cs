using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin
{
    public class DeleteMessageModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public DeleteMessageModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            else
            {
                ViewData["username"] = HttpContext.Session.GetString("Name");
            }
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.tbl_Contact.FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
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

            Contact = await _context.tbl_Contact.FindAsync(id);

            if (Contact != null)
            {
                _context.tbl_Contact.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ShowMessages");
        }
    }
}
