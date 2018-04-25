using Microsoft.EntityFrameworkCore;
using System;
//using System.Data./*Entity*/;
using System.Linq;
using System.Data;
using System.Collections.Generic;
//http://www.talkingdotnet.com/create-sqlite-db-entity-framework-core-code-first/
namespace ConsoleApp1
{
   public class Program
    {
        public static void Main(string[] args)
        {
            using (var dataContext = new CourseraContext())
            {
                //dataContext.Categories.Add(new Category() { CategoryName = "Clothing" });
                //dataContext.Categories.Add(new Category() { CategoryName = "Footwear" });
                //dataContext.Categories.Add(new Category() { CategoryName = "Accessories" });
                //dataContext.SaveChanges();

                //foreach (var cat in dataContext.Categories.ToList())
                //{
                //    Console.WriteLine($"CategoryId= {cat.CategoryID}, CategoryName = {cat.CategoryName}");
                //}

                //Console.ReadLine();
            }



        }

        public static void initiatedb()
        {

            using (var dataContext = new CourseraContext())
            {
               
            }
        }

        public class CourseraContext : DbContext
        {
            private static bool _created = false;
            public CourseraContext()
            {
                if (!_created)
                {
                    _created = true;
                    Database.EnsureDeleted();
                    Database.EnsureCreated();
                }
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
            {
                optionbuilder.UseSqlite(@"Data Source=C:\temp\Sample3.db"); //https://stackoverflow.com/questions/43098065/entity-framework-core-dbcontextoptionsbuilder-does-not-contain-a-definition-f
            }
            //internal class CourseraContext : DbContext
            //{
            public DbSet<Course> Courses { get; set; }

            public DbSet<Student> Students { get; set; }
            //}
            //public DbSet<Category> Categories { get; set; }
        }
        //public class Category
        //{
        //    public int CategoryID { get; set; }
        //    public string CategoryName { get; set; }

        //}
        public class Course
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }

            public virtual List<Student> Students { get; set; }
        }

        public class Student
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int CourseId { get; set; }

            public virtual Course Course { get; set; }
        }
    }
}