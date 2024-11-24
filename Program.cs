//VuManhTri_2280603381
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tao danh sach
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Cong", Age = 18 },
                new Student { Id = 2, Name = "Tri", Age = 20 },
                new Student { Id = 3, Name = "Cuong", Age = 16 },
                new Student { Id = 4, Name = "Phuc", Age = 19 },
                new Student { Id = 5, Name = "Khiem", Age = 17 }
            };



            // a. In danh sach toan bo danh sach hoc sinh
            Console.WriteLine("Danh sach hoc sinh:");
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }


            // b. Tim va in danh sach cac hoc sinh co tuoi tu 15 đen 18
            Console.WriteLine("\nHọc sinh tu 15 đen 18 tuoi la: ");
            var ageGroup = students.Where(s => s.Age >= 15 && s.Age <= 18);
            foreach (var student in ageGroup)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }



            // c. Tim va in ra hoc sinh co ten bat đau bang chu "A"
            Console.WriteLine("\nHoc sinh co ten bat đau bang chu 'A' la: ");
            var nameStartsWithA = students.Where(s => s.Name.StartsWith("A"));
            foreach (var student in nameStartsWithA)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }



            // d. Tinh tong tuoi cua tat ca cac hoc sinh trong danh sach
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nTong tuoi cua tat ca hoc sinh la: {totalAge}");



            // e. Tim va in hoc sinh co so tuoi lon nhat
            int maxAge = students.Max(s => s.Age);
            var oldestStudents = students.Where(s => s.Age == maxAge);
            Console.WriteLine("\nHoc sinh co so tuoi lon nhat la: ");
            foreach (var student in oldestStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }



            // f. Sap xep danh sach theo tuoi tang dan va in ra danh sach
            Console.WriteLine("\nDanh sach hoc sinh theo tuoi tang dan: ");
            var sortedStudents = students.OrderBy(s => s.Age);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }
        }
    }
}