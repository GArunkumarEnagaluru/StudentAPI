using StudentAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student { Name = "Sunil", SchoolName = "Vignan High School" },
                    new Student { Name = "Anil", SchoolName = "Vignan High School" },
                    new Student { Name = "Ravi", SchoolName = "Vignan High School" },
                    new Student { Name = "Kiran", SchoolName = "Vignan High School" },
                    new Student { Name = "Suresh", SchoolName = "Vignan High School" },
                    new Student { Name = "Rajesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Mahesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Naresh", SchoolName = "Vignan High School" },
                    new Student { Name = "Ramesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Venkatesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Ganesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Lokesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Mounesh", SchoolName = "Vignan High School" },
                    new Student { Name = "Jagadish", SchoolName = "Vignan High School" },
                    new Student { Name = "Girish", SchoolName = "Vignan High School" }
                };

                context.Students.AddRange(students);
                context.SaveChanges();

                var examResults = new List<ExamResult>();
                foreach (var student in students)
                {
                    examResults.Add(new ExamResult
                    {
                        StudentId = student.Id,
                        English = 75,
                        Telugu = 80,
                        Hindi = 85,
                        Mathematics = 90,
                        Physics = 95,
                        Social = 70
                    });
                }
                context.ExamResults.AddRange(examResults);
                context.SaveChanges();
            }
        }
    }
}
