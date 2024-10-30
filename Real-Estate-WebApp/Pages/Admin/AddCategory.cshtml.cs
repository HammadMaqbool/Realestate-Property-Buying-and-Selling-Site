using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;
namespace Real_Estate_WebApp.Pages.Admin;

public class AddCategoryModel : PageModel
{
    AppDbContext db;

    [BindProperty]
    public Category Category { get; set; }

    public AddCategoryModel(AppDbContext _db)
    {
        db = _db;
    }

    public void OnGet()
    {
      if(HttpContext.Session.GetString("flag") !="true")
        {
            Response.Redirect("/Admin/Login");
        }
      else
        {
            ViewData["username"] = HttpContext.Session.GetString("Name");
        }
    }
    public IActionResult OnPost()
    {
        if(ModelState.IsValid)
        {
            db.tbl_Category.Add(Category);
            db.SaveChanges();

            return RedirectToPage("ShowCategories");
        }
        return Page();
    }
}
