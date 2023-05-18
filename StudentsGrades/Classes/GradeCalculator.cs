using StudentsGrades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Classes
{
    public class GradeCalculator : IGradeCalculator
    {
        public decimal CalculateAverageGrade(Student student)
        {
            if (student.Grades.Count == 0)
                return 0;

            return (decimal)student.Grades.Average();
        }
    }
}
