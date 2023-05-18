using StudentsGrades.Classes;
using StudentsGrades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of the required dependencies
            List<Student> students = new List<Student>();
            IStudentRepository studentRepository = new StudentRepository(students);
            IGradeCalculator gradeCalculator = new GradeCalculator();
            IGradeExporter gradeExporter = new GradeExporter();


            // Create an instance of the GradeManagement
            var gradeManagementSystem = new GradeManagement(studentRepository, gradeCalculator, gradeExporter);

            // Add new students
            gradeManagementSystem.AddNewStudent("John Doe", 1);
            gradeManagementSystem.AddNewStudent("Jane Smith", 2);
            gradeManagementSystem.AddNewStudent("Martin Charles", 3);
            gradeManagementSystem.AddNewStudent("Steve Smith", 4);

            // Add grades
            gradeManagementSystem.AddGrade(1, 6);
            gradeManagementSystem.AddGrade(2, 5);
            gradeManagementSystem.AddGrade(3, 4);
            gradeManagementSystem.AddGrade(4, 6);
            gradeManagementSystem.AddGrade(5, 4);
            gradeManagementSystem.AddGrade(6, 6);
            gradeManagementSystem.AddGrade(7, 4);
            gradeManagementSystem.AddGrade(8, 6);

            // Print all students
            Console.WriteLine("Student Grades:");
            Console.WriteLine("---------------");
            foreach (var student in studentRepository.GetStudents())
            {
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Grades: {string.Join(", ", student.Grades)}");
                Console.WriteLine("---------------");
            }


            // Calculate average grades
            var averageGrade1 = gradeManagementSystem.CalculateAverageGrade(1);
            var averageGrade2 = gradeManagementSystem.CalculateAverageGrade(2);
            var averageGrade3 = gradeManagementSystem.CalculateAverageGrade(3);
            var averageGrade4 = gradeManagementSystem.CalculateAverageGrade(4);

            Console.WriteLine($"Average grade for student 1: {averageGrade1}");
            Console.WriteLine($"Average grade for student 2: {averageGrade2}");
            Console.WriteLine($"Average grade for student 3: {averageGrade3}");
            Console.WriteLine($"Average grade for student 4: {averageGrade4}");

            // Export grades to a file on the desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, Const.FilePath);

            gradeManagementSystem.ExportGrades(filePath);

            Console.WriteLine("Grades exported successfully.");
        }
    }
}
