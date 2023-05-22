using NLog;
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
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();
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
                logger.Error(ex);
                Console.WriteLine(Const.ExportGradesError);
                throw; // Rethrow the exception
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
