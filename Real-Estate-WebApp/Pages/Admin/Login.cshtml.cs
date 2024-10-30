using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin
{
    public class LoginModel : PageModel
    {
        AppDbContext db;

        [BindProperty]
        public User User { get; set; }
        public LoginModel(AppDbContext _db)
        {
            db = _db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("flag", "false");
                var UserDetails = db.tbl_User.Where(x => x.Username == User.Username && x.Password == User.Password).FirstOrDefault();
                if (UserDetails != null)
                {
                    HttpContext.Session.SetString("flag", "true");
                    HttpContext.Session.SetString("Name", UserDetails.Name);

                    return RedirectToPage("/Admin/Index", true);
                }
                else
                {
                    ViewData["ErrorMessage"] = "Invalid username or password!";
                    return Page();
                }
            }
            return Page();
        }
    }
}
