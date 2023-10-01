using System;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Orders> Orders {get; set;}

        public DbSet<Products> Products { get; set; }

        public DbSet<Cart> Cart { get; set; }
    }
}
