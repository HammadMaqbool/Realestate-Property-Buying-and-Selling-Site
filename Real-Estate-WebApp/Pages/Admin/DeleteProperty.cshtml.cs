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
    public class DeletePropertyModel : PageModel
    {
        private readonly Real_Estate_WebApp.Data.AppDbContext _context;
       IWebHostEnvironment _environment;
        public DeletePropertyModel(Real_Estate_WebApp.Data.AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Property Property { get; set; }

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

            Property = await _context.tbl_Property.FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string imagename)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.tbl_Property.FindAsync(id);

            if (Property != null)
            {
                _context.tbl_Property.Remove(Property);
                DeleteImage(imagename);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ShowProperties");
        }

        public void DeleteImage(string ImageName)
        {
            var FolderPath = Path.Combine(_environment.WebRootPath, "uploaded_images");
            var ImagePath = Path.Combine(FolderPath, ImageName);

            FileInfo file = new FileInfo(ImagePath);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        

    }
}
