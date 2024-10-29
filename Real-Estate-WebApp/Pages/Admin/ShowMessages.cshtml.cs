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
    public class ShowMessagesModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;

        public ShowMessagesModel(Real_Estate_WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.tbl_Contact.ToListAsync();
        }
    }
}
