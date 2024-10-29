using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages
{
    public class Contact_USModel : PageModel
    {
        AppDbContext db;
        [BindProperty]
        public Profile Profile { get; set; }

        [BindProperty]
        public Contact Contact { get; set; }
        public Contact_USModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Profile = db.tbl_Profile.FirstOrDefault();
        }

        public IActionResult OnPost() 
         {
            db.tbl_Contact.Add(Contact);
            db.SaveChanges();

            return RedirectToPage("Contact-Us");
         }
    }
}
