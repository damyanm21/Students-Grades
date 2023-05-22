using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Interfaces
{
    public interface IStudent
    {
        /// <summary>
        /// Gets or sets the ID, name of the student.
        /// </summary>
        int Id { get; set; }
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of grades for the student.
        /// </summary>
        List<int> Grades { get; set; }
    }
}
