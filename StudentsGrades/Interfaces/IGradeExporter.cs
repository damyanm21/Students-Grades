using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Interfaces
{
    public interface IGradeExporter
    {
        /// <summary>
        /// Exports grades for students to a file.
        /// </summary>
        /// <param name="students">An enumerable collection of students.</param>
        /// <param name="filePath">The path of the file to export to.</param>
        void ExportGrades(IEnumerable<Student> students, string filePath);
    }
}
