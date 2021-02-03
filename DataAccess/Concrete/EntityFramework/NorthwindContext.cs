using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : DB (Veritabanı) tabloları ile proje classlarımız arasında bağlantı yani ilişkilendirir.
    public class NorthwindContext : DbContext
    {
        //Context ile Projenin hangi veritabanı ile ilişkilendirileceğini belirtiyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NorthWind;Trusted_Connection=true");

        }
        //DbSet : hangi nesne hangi nesneye karşılık geleceğini belirliyoruz.
        //DB deki Products tablom ile Product nesnemi birbirine bağla
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
