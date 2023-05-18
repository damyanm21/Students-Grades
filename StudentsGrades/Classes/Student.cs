using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    public class Student
    {
        /// <summary>
        /// Gets or sets the ID, name of the student.
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of grades for the student.
        /// </summary>
        public List<int> Grades { get; set; } = new List<int>();
    }
}
