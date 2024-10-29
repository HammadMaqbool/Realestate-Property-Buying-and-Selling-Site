using Microsoft.AspNetCore.Mvc;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.ViewComponents
{
    public class SocialLinksViewComponent : ViewComponent
    {
        AppDbContext db;
        public SocialNetworks socialNetworks { get; set; }
        public SocialLinksViewComponent(AppDbContext _db)
        {
            db = _db;   
        }

        public IViewComponentResult Invoke()
        {
            socialNetworks = db.tbl_SocialNetworks.FirstOrDefault();
            return View(socialNetworks);
        }
    }
}
