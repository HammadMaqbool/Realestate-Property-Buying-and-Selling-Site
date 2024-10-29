using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages
{
    public class Property_for_rentModel : PageModel
    {
        AppDbContext _db;
        public List<Property> Property { get; set; }
        public Property_for_rentModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Property = _db.tbl_Property.ToList();
        }
    }
}
