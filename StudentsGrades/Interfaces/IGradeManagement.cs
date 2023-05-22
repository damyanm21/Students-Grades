using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Interfaces
{
    public interface IGradeManagement
    {
        /// <summary>
        /// Adds a new student with the specified name and ID.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <param name="id">The ID of the student.</param>
        void AddNewStudent(string name, int id);

        /// <summary>
        /// Adds a grade to the student with the specified ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="grade">The grade to be added.</param>
        void AddGrade(int studentId, int grade);

        /// <summary>
        /// Calculates the average grade for the student with the specified ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>The average grade of the student.</returns>
        decimal CalculateAverageGrade(int studentId);

        /// <summary>
        /// Exports the grades of all students to the specified file path.
        /// </summary>
        /// <param name="filePath">The file path to export the grades to.</param>
        void ExportGrades(string filePath);

    }
}
