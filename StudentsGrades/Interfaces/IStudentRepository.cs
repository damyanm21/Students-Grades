using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Interfaces
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Adds a student to the repository.
        /// </summary>
        /// <param name="student">The student object.</param>
        void AddStudent(Student student);

        /// <summary>
        /// Adds a grade for a student.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="grade">The grade to add.</param>
        void AddGrade(int studentId, int grade);

        /// <summary>
        /// Retrieves a student from the repository.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>The student object.</returns>
        Student GetStudent(int studentId);

        /// <summary>
        /// Retrieves all students from the repository.
        /// </summary>
        /// <returns>An enumerable collection of students.</returns>
        IEnumerable<Student> GetStudents();
    }
}
