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
    public class DeleteTestimonialModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public DeleteTestimonialModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Testimonial Testimonial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Testimonial = await _context.tbl_Testimonials.FirstOrDefaultAsync(m => m.Id == id);

            if (Testimonial == null)
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

            Testimonial = await _context.tbl_Testimonials.FindAsync(id);

            if (Testimonial != null)
            {
                _context.tbl_Testimonials.Remove(Testimonial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ShowTestimonials");
        }
    }
}
