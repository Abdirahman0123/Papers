using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Papers.Models;

namespace Papers.Models
{

    // This class provides connection to the database and
    // allows the application to interact with the DB
    public class ProductDbContext: DbContext
    {
        // ProductDbContext uses DbContextOptions class in order to work as
        // DbContextOptions class carries information such database proivder
        public ProductDbContext (DbContextOptions<ProductDbContext> options): base(options)
        { }

        // DbSets map to their respective tables in the database and used for crud operations
        public DbSet<Product> Product { get; set; }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Order> Orders { get; set; }      

        // This method seeds the database with initial data
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder specifies the table and HasDate populates it
             Each object ( for example, new Supplier ) represents
             one record*/
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier {

                    SupplierId = 1,
                    Name = "Card Factory",
                    Email = "CardFactory@hotmail.com",
                    Phone = "020 0022 1234"
                },

                new Supplier
                {
                    SupplierId = 2,
                    Name = "WHSmith",
                    Email = "WHSmith@hotmail.com",
                    Phone = "020 2857 1234"
                },

                new Supplier
                {
                    SupplierId = 3,
                    Name = "The Works",
                    Email = "TheWorks@hotmail.com",
                    Phone = "020 2587 8541"
                }

                );

            modelBuilder.Entity<Product>().HasData( 
                new Product
                {   Id = 1,
                    Name = "A4 Refill Pad: 80 Sheets",
                    Category = "Notepads",
                    Price = 2,
                    SupplierId = 2,
                },

                 new Product
                 {  Id = 2,
                     Name = "Pukka Black Box File",
                     Category = "Files & Folders",
                     Price = 4,
                     SupplierId = 1,
                 },

                 new Product
                 {  Id = 3,
                     Name = "5 Tier Gel Pen Case: Set of 60",
                     Category = "Pens & Pencils",
                     Price = 8,
                     SupplierId = 3,
                 },

                 new Product
                 {
                     Id = 4,
                     Name = "Colouring Pencils: Pack of 15",
                     Category = "Pens & Pencils",
                     Price = 1,
                     SupplierId = 2,
                 }

                );
        }
             
    }
}

