using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin;

public class ShowCategoriesModel : PageModel
{
    AppDbContext db;
    public List<Category> Categories { get; set; }
    public ShowCategoriesModel(AppDbContext _db)
    {
        db = _db;
    }

    public IActionResult OnGetDelete(int Id)
    {
        var CategoryToDelete = db.tbl_Category.Find(Id);
        db.tbl_Category.Remove(CategoryToDelete);
        db.SaveChanges();

        return RedirectToPage("ShowCategories");
    }

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
        Categories = db.tbl_Category.ToList();
    }
}
