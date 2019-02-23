using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                var student = new Student() { Name = "Muhammad Mustafa" };

                var subjectDiscret = new Subject() { Title = "Discreet Structures" };
                var subjectMaths = new Subject() { Title = "Mathametics"};

                student.Subjects.Add(subjectDiscret);
                student.Subjects.Add(subjectMaths);

                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }

    public class Student
    {
        public Student()
        {
            this.Subjects = new List<Subject>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }

        public virtual Student Student { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
