using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages
{
   
    public class IndexModel : PageModel
    {
        AppDbContext db;
        public List<Property> Property { get; set; }
        public Profile Profile { get; set; }
        public List<Testimonial> Testimonial { get; set; }
        public List<Category> Category { get; set; }

        public IndexModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Profile = db.tbl_Profile.FirstOrDefault();
            Property = db.tbl_Property.ToList();
            Testimonial = db.tbl_Testimonials.ToList();
            Category = db.tbl_Category.ToList();
        }



    }
}
