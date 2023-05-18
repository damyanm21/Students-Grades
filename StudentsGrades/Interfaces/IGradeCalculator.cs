using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Interfaces
{

    public interface IGradeCalculator
    {
        /// <summary>
        /// Calculates the average grade for a student.
        /// </summary>
        /// <param name="student">The student object.</param>
        /// <returns>The average grade as a decimal.</returns>
        decimal CalculateAverageGrade(Student student);
    }
}
