using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Real_Estate_WebApp.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            if(HttpContext.Session.IsAvailable)
            {
                HttpContext.Session.Clear();
                Response.Redirect("/Admin/Login");
            }
        }
    }
}
