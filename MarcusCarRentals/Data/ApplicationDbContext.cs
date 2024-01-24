using MarcusCarRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcusCarRentals.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
