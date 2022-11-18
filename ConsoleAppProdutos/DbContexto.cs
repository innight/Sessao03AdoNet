using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1_Models;

namespace ConsoleAppProdutos
{
    class DbContexto : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=products;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Bebidas",
                    Description = "Bebidas ...."
                },
                new Category
                {
                    Id = 2,
                    Name = "Comida",
                    Description = "Comidas ...."
                }
            );

            modelBuilder.Entity<SubCategory>().HasData(
               new SubCategory
               {
                   Id = 1,
                   Name = "Refrigentes",
                   Description = "Refrigentes ....",
                   CategoryId = 1
               },
               new SubCategory
               {
                   Id = 2,
                   Name = "Aguas",
                   Description = "Aguas ....",
                   CategoryId = 1
               },
               new SubCategory
               {
                   Id = 3,
                   Name = "Porco",
                   Description = "Porco ....",
                   CategoryId = 2
               },
               new SubCategory
               {
                   Id = 4,
                   Name = "Frango",
                   Description = "Frango ....",
                   CategoryId = 2
               }
           );



            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Name = "Agua Frize",
                     Description = "Agua Frize ....",
                     SubCategoryId = 2
                 },
                    new Product
                    {
                        Id = 2,
                        Name = "Sumol",
                        Description = "Sumol Ananas ....",
                        SubCategoryId = 1

                    }, new Product
                    {
                        Id = 3,
                        Name = "Bifes",
                        Description = "Bifes... ....",
                        SubCategoryId = 4

                    }, new Product
                    {
                        Id = 4,
                        Name = "Costelas",
                        Description = "Costelas... ....",
                        SubCategoryId = 4

                    }

               );
        }
    }
}
