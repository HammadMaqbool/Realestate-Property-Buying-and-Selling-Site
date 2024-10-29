using System.ComponentModel.DataAnnotations;

namespace Real_Estate_WebApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter category name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter slug")]
        public string slug { get; set; }
    }
}
