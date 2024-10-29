using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin
{
    public class UpdateSocialNetworksModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public UpdateSocialNetworksModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SocialNetworks SocialNetworks { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SocialNetworks = await _context.tbl_SocialNetworks.FirstOrDefaultAsync(m => m.Id == id);

            if (SocialNetworks == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SocialNetworks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialNetworksExists(SocialNetworks.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ShowSocialNetworks");
        }

        private bool SocialNetworksExists(int id)
        {
            return _context.tbl_SocialNetworks.Any(e => e.Id == id);
        }
    }
}
