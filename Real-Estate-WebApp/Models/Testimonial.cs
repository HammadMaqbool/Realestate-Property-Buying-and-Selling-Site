using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate_WebApp.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
