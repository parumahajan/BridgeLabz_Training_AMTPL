using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.LINQ
{
    public class Practice2
    {
        public class Student
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Dept { get; set; }
        }

        public static void Main(string[] args)
        {
            // LIST
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Pranav", Dept = "CS" },
                new Student { Id = 2, Name = "Dinesh", Dept = "CS" },
                new Student { Id = 3, Name = "Dilshad", Dept = "CS" }
            };

            // RESULT

            var result = students
                .GroupBy(student => student.Dept)
                .Select(group => new
                {
                    DeptName = group.Key,
                    StdCount = group.Count()
                });
            
            
            // DISPLAY
            foreach (var item in result)
            {
                Console.WriteLine("Dept: " + item.DeptName, "Count: " + " , " + "Count: " + item.StdCount); 
            }
        }
    }
}

