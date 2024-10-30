
using System.ComponentModel.DataAnnotations;

namespace Real_Estate_WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Required(ErrorMessage ="Please enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

    }
}
