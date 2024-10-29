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
    public class ShowTestimonialsModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public ShowTestimonialsModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Testimonial> Testimonial { get;set; }

        public async Task OnGetAsync()
        {
            Testimonial = await _context.tbl_Testimonials.ToListAsync();
        }
    }
}
