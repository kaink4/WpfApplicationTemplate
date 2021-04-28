using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplicationTemplate.DataAccess.Entities;

namespace WpfApplicationTemplate.DataAccess
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) 
            : base(options)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sample Product 1"
                },
                new Product
                {
                    Id = 2,
                    Name = "Sample Product 2"
                });
        }

        public DbSet<Product> Products { get; set; }
    }
}
