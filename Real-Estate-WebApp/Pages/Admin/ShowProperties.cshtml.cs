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
    public class ShowPropertiesModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public ShowPropertiesModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; }

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            else
            {
                ViewData["username"] = HttpContext.Session.GetString("Name");
            }
            Property = await _context.tbl_Property.ToListAsync();
        }
    }
}
