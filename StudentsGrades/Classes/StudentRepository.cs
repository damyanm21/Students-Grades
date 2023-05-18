using StudentsGrades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Classes
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void AddGrade(int studentId, int grade)
        {
            var student = GetStudent(studentId);
            student.Grades.Add(grade);
        }

        public Student GetStudent(int studentId)
        {
            return students.FirstOrDefault(s => s.Id == studentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }

    }
}
