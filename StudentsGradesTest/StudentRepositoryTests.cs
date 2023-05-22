using NUnit.Framework;
using StudentsGrades.Classes;
using StudentsGrades;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentsGrades.Interfaces;

namespace StudentRepositoryTests
{
    public class StudentRepositoryTests
    {
        private List<Student> students;
        private StudentRepository repository;


        [SetUp]
        public void SetUp()
        {
            students = new List<Student>();
            repository = new StudentRepository(students);

        }

        [Test]
        public void AddStudent_StudentAddedSuccessfully()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "John Doe" };

            // Act
            repository.AddStudent(student);

            // Assert
            Assert.Contains(student, students);
        }

        [Test]
        public void AddGrade_GradeAddedSuccessfully()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "John Doe" };
            repository.AddStudent(student);

            // Act
            repository.AddGrade(student.Id, 6);

            // Assert
            Assert.AreEqual(6, student.Grades.Single());
        }

        [Test]
        public void GetStudent_ExistingStudentId_ReturnsStudent()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "John Doe" };
            repository.AddStudent(student);

            // Act
            var result = repository.GetStudent(student.Id);

            // Assert
            Assert.AreEqual(student, result);
        }

        [Test]
        public void GetStudent_NonExistingStudentId_ReturnsNull()
        {
            // Act
            var result = repository.GetStudent(999);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetStudents_ReturnsAllStudents()
        {
            // Arrange
            var student1 = new Student { Id = 1, Name = "John Doe" };
            var student2 = new Student { Id = 2, Name = "Jane Smith" };
            repository.AddStudent(student1);
            repository.AddStudent(student2);

            // Act
            var result = repository.GetStudents().ToList();

            // Assert
            Assert.Contains(student1, result);
            Assert.Contains(student2, result);
        }
    }
}