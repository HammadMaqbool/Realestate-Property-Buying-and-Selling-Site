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
    public class DeleteProfileModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public DeleteProfileModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profile Profile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profile = await _context.tbl_Profile.FirstOrDefaultAsync(m => m.Id == id);

            if (Profile == null)
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

            Profile = await _context.tbl_Profile.FindAsync(id);

            if (Profile != null)
            {
                _context.tbl_Profile.Remove(Profile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ShowProfile");
        }

       
    }
}
