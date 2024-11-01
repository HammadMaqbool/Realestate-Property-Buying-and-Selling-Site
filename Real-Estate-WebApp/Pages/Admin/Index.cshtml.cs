using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Real_Estate_WebApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if (HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            else
            {
                ViewData["username"] = HttpContext.Session.GetString("Name");
            }
        }
    }
}
