using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages
{
    public class Property_for_saleModel : PageModel
    {
        AppDbContext db;
        public List<Property> Property { get; set; }
        public Property_for_saleModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Property = db.tbl_Property.ToList();
        }
    }
}
