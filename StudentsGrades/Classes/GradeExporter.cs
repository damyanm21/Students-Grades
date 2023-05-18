using StudentsGrades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Classes
{
    public class GradeExporter : IGradeExporter
    {
        public void ExportGrades(IEnumerable<Student> students, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var student in students)
                    {
                        var averageGrade = CalculateAverageGrade(student);
                        writer.WriteLine($"{student.Id},{student.Name},{averageGrade}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while exporting grades: {ex.Message}");
            }
        }

        private decimal CalculateAverageGrade(Student student)
        {
            if (student.Grades.Count == 0)
                return 0;

            decimal sum = 0;
            foreach (var grade in student.Grades)
            {
                sum += grade;
            }

            return Math.Round(sum / student.Grades.Count, 2);
        }
    }
}
