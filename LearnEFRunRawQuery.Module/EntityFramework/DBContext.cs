using LearnEFRunRawQuery.Module.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFRunRawQuery.Module.EntityFramework
{
    public class DBContext : DbContext
    {
        public virtual DbSet<ChildProduct> ChildProducts { set; get; }
        public virtual DbSet<AdultProduct> AdultProducts { set; get; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;User=sa;Pwd=admin123;Database=learnRawQuery");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChildProduct>().HasIndex(x => x.Id);
            modelBuilder.Entity<AdultProduct>().HasIndex(x => x.Id);

            var childProduct1 = new ChildProduct() { Id=  1, Name = "Kaos Spiderman", Stok = 5, Price = 50000 };
            var childProduct2 = new ChildProduct() { Id = 2, Name = "Kaos Superman", Stok = 10, Price = 40000 };
            var childProduct3 = new ChildProduct() { Id = 3, Name = "Kaos Iron Man", Stok = 15, Price = 80000 };
            modelBuilder.Entity<ChildProduct>().HasData(childProduct1);
            modelBuilder.Entity<ChildProduct>().HasData(childProduct2);
            modelBuilder.Entity<ChildProduct>().HasData(childProduct3);

            var adultProduct1 = new AdultProduct() { Id = 1, Name = "Kaos Pevita", Stok = 51, Price = 50000 };
            var adultProduct2 = new AdultProduct() { Id = 2, Name = "Kaos John Wick", Stok = 101, Price = 40000 };
            var adultProduct3 = new AdultProduct() { Id = 3, Name = "Kaos Dwyne Johnson", Stok = 151, Price = 80000 };
            modelBuilder.Entity<AdultProduct>().HasData(adultProduct1);
            modelBuilder.Entity<AdultProduct>().HasData(adultProduct2);
            modelBuilder.Entity<AdultProduct>().HasData(adultProduct3);
        }
    }
}
