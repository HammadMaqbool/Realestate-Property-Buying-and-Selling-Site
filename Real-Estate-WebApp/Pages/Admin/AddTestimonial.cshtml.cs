using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages.Admin;

public class AddTestimonialModel : PageModel
{
    [BindProperty]
    public Testimonial Testimonial { get; set; }
    AppDbContext db;
    IWebHostEnvironment env;
    public AddTestimonialModel(AppDbContext _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }
    public void OnGet()
    {
    }

    public void OnPost()
    {
        string ImageName = Testimonial.Photo.FileName;

        var FolderPath = Path.Combine(env.WebRootPath, "uploaded_images");
        //ProjectName/wwwroot/uploaded_images
        var ImagePath = Path.Combine(FolderPath, ImageName);
        //ProjectName/wwwroot/uploaded_images/image.jpeg
        var myFileStream = new FileStream(ImagePath, FileMode.Create);
        Testimonial.Photo.CopyTo(myFileStream);
        Testimonial.Image = ImageName;

        db.tbl_Testimonials.Add(Testimonial);
        db.SaveChanges();
    }
}
