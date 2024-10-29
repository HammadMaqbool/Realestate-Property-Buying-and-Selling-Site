using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_Estate_WebApp.Data;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Pages
{
    public class SearchResultsModel : PageModel
    {
        AppDbContext db;
        public List<Property> SearchedProperties { get; set; }

        public SearchResultsModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
        }

        public void OnPost(string keyword, string selectedcategory)
        {
            SearchedProperties = db.tbl_Property.Where(x => x.Title.Contains(keyword) && x.Category == selectedcategory).ToList();
            if (SearchedProperties.Count > 0)
            {
                ViewData["flag"] = "true";
            }
        }
    }
}
