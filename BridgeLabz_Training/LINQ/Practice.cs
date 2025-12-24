using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.LINQ
{
    public class Practice
    {

        public class Student
        {
            public int Id { get; set; }                     // Student ID
            public required string Name { get; set; }       // Student Name
            public required string Department { get; set; } // Student Department
        }

        public static void Main(string[] args)
        {
            // List of students
            List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Pranav",  Department = "CS" },
            new Student { Id = 2, Name = "Dinesh",  Department = "IT" },
            new Student { Id = 3, Name = "Dilshad", Department = "CS"}
        };

            // LINQ query: Group by Department and count students
            var result = students
                .GroupBy(student => student.Department)
                .Select(group => new
                {
                    DepartmentName = group.Key,   // Department name
                    StudentCount = group.Count()  // Number of students
                });

            // Display result
            foreach (var item in result)
            {
                Console.WriteLine("Department: " + item.DepartmentName + " , " + "Count: " + item.StudentCount);
            }
        }
    }
}