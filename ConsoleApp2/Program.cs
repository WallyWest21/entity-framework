using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite.EF6;
using Microsoft.Data.Sqlite;
using System.Data.Entity.Core.Common;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            EnterCourse();
        }
   
        private static void EnterCourse()
        {
            string name = "";

            while (name != "0")
            {
                Console.WriteLine("Enter name of course (0 to exit):");
                name = Console.ReadLine().Trim();
                if (name != "0")
                {
                    using (var db = new CourseraContext())
                    {
                        Course course = new Course();
                        course.Name = name;
                        db.Courses.Add(course);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
    internal class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public virtual List<Student> Students { get; set; }
    }

    class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
    internal class CourseraContext : DbContext
       
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
    }
    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SqliteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }
}
