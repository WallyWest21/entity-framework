using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1;
namespace ef_sqlite_test
{ 
    //https://stackoverflow.com/questions/29129796/no-entity-framework-provider-found-for-ef-6-and-sqlite-1-0-96-0
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnterCourse2();
        }
        private void EnterCourse2()
        {
            string name = "thermo" + DateTime.Now.ToString();
            using (var db = new CourseraContext())
            {
                Course course = new Course();
                course.Name = name;
                db.Courses.Add(course);
                db.SaveChanges();
            }
            ConsoleApp1.Program.initiatedb();
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
}
