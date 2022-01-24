using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ApplicationDbContext : DbContext
    {
       private string _connectionString =
          "Server=(localdb)\\mssqllocaldb;Database=StoreDB;Trusted_Connection=True;";
     /*  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }*/
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.NazwaProduktu)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

