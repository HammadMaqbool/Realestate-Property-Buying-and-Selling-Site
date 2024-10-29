using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin;

public class UpdateCategoryModel : PageModel
{
    AppDbContext db;

    [BindProperty]
    public Category Category { get; set; }
    public UpdateCategoryModel(AppDbContext _db)
    {
        db = _db;
    }
    public void OnGet(int Id)
    {
        Category = db.tbl_Category.Find(Id);
    }

    public IActionResult OnPost()
    {
        if(ModelState.IsValid)
        {
            db.tbl_Category.Update(Category);
            db.SaveChanges();

            return RedirectToPage("ShowCategories");
        }

        return Page();
       
    }
}
