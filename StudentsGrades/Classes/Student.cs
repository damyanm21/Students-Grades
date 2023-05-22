using StudentsGrades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    public class Student : IStudent
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Grades { get; set; } = new List<int>();
    }
}
