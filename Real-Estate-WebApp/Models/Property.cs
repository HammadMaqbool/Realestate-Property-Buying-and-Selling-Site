using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate_WebApp.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int Area { get; set; }
        public int Number_of_Bedrooms { get; set; }
        public int Number_of_Baths { get; set; }
        public string Featured { get; set; }
        public string image { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
