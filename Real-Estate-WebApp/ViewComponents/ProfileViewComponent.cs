using Microsoft.AspNetCore.Mvc;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        AppDbContext db;
        public Profile Profile { get; set; }
        public ProfileViewComponent(AppDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            Profile = db.tbl_Profile.FirstOrDefault();
            return View(Profile);   
        }
    }
}
