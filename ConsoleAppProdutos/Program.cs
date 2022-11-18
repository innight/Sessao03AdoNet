using System;
using ClassLibrary1_Models;

namespace ConsoleAppProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seeding BD, Data Annotations");

            using (var db = new DbContexto())
            {
                Category c = new Category() { Description = "Refrigente" };
                c.Description = "REFRI";

                SubCategory sc = new SubCategory() { Description = "Sumo", CategoryId = 1 };
                sc.Description = "Sumo";
                sc.CategoryId = 1;

                Product p = new Product() { Name = "Cocacola", Price = 33, SubCategoryId = 1 };

                db.Categorys.Add(c);
                db.SubCategorys.Add(sc);
                db.SaveChanges();

                db.Products.Add(p);
                var result = db.SaveChanges();

                Console.WriteLine($"Results products: {result}");

            }

            Console.ReadKey();
        }
    }
}
