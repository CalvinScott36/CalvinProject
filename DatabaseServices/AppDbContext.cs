using CalvinProject.DatabaseServices;
using Microsoft.EntityFrameworkCore;

namespace CalvinProject.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options): base(options) {

        }

        public DbSet<User> Users {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<CartItem> CartItems {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        }
    }
}
