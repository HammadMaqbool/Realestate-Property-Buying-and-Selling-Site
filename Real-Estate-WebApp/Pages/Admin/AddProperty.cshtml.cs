using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin;

public class AddPropertyModel : PageModel
{
    AppDbContext db;
    IWebHostEnvironment env;

    [BindProperty]
    public Property Property { get; set; }

    public List<Category> Categories { get; set; }

    public AddPropertyModel(AppDbContext _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
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

    public IActionResult OnPost()
    {
        string ImageName = Property.Photo.FileName;

        var FolderPath = Path.Combine(env.WebRootPath, "uploaded_images");
        //ProjectName/wwwroot/uploaded_images
        var ImagePath = Path.Combine(FolderPath, ImageName);
        //ProjectName/wwwroot/uploaded_images/image.jpeg
        var myFileStream = new FileStream(ImagePath, FileMode.Create);
        Property.Photo.CopyTo(myFileStream);
        Property.image = ImageName;

        db.tbl_Property.Add(Property);
        db.SaveChanges();
        myFileStream.Dispose();

        return RedirectToPage("AddProperty");
    }

}
