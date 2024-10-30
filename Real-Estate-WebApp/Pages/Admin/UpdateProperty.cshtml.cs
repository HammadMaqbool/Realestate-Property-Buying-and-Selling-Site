using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin;

public class UpdatePropertyModel : PageModel
{
    AppDbContext db;
    IWebHostEnvironment env;

    public List<Category> Categories { get; set; }

    [BindProperty]
    public Property Property { get; set; }

    public UpdatePropertyModel(AppDbContext _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }
    public void OnGet(int Id)
    {
        if (HttpContext.Session.GetString("flag") != "true")
        {
            Response.Redirect("/Admin/Login");
        }
        else
        {
            ViewData["username"] = HttpContext.Session.GetString("Name");
        }
        Property = db.tbl_Property.Find(Id);
        Categories = db.tbl_Category.ToList();
    }

    public IActionResult OnPost()
    {
        if(Property.Photo != null)
        {
            string ImageName = Property.Photo.FileName;
            string OldImageName = Property.image;

            var FolderPath = Path.Combine(env.WebRootPath, "uploaded_images");
            var ImagePath = Path.Combine(FolderPath, ImageName);

            var myFileStream = new FileStream(ImagePath, FileMode.Create);
            Property.Photo.CopyTo(myFileStream);
            myFileStream.Dispose();

            DeleteImage(OldImageName);

            Property.image = ImageName;

            db.tbl_Property.Update(Property);
            db.SaveChanges();

            return RedirectToPage("ShowProperties");
        }
        else
        {
            db.tbl_Property.Update(Property);
            db.SaveChanges();

            return RedirectToPage("ShowProperties");
        }
    }

    public void DeleteImage(string OldImageName)
    {
        var FolderPath = Path.Combine(env.WebRootPath, "uploaded_images");
        var imagepath = Path.Combine(FolderPath, OldImageName);

        FileInfo file = new FileInfo(imagepath);
        if (file.Exists)
        {
            file.Delete();
        }

    }
}
