using Microsoft.EntityFrameworkCore;
using Real_Estate_WebApp.Models;

namespace Real_Estate_WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Define the tables of the project
        public DbSet<Category> tbl_Category { get; set; }
        public DbSet<Property> tbl_Property { get; set; }
        public DbSet<Profile> tbl_Profile { get; set; }
        public DbSet<User> tbl_User { get; set; }
        public DbSet<SocialNetworks> tbl_SocialNetworks { get; set; }
        public DbSet<Testimonial> tbl_Testimonials { get; set; }
        public DbSet<Contact> tbl_Contact { get; set; }


    }
}
