using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class HomeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }
}