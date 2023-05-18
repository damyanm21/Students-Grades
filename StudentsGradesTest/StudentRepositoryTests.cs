using NUnit.Framework;
using StudentsGrades.Classes;
using StudentsGrades;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentsGrades.Interfaces;

namespace StudentsGrades.Classes
{
    public class StudentRepositoryTests
    {
        private StudentRepository studentRepository;

        [SetUp]
        public void SetUp()
        {
            studentRepository = new StudentRepository();
        }

        [Test]
        public void AddStudent_StudentAddedSuccessfully()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "John Doe" };

            // Act
            studentRepository.AddStudent(student);

            // Assert
            var addedStudent = studentRepository.GetStudent(1);
            Assert.AreEqual(student, addedStudent);
        }

        [Test]
        public void AddGrade_GradeAddedSuccessfully()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "John Doe" };
            studentRepository.AddStudent(student);

            // Act
            studentRepository.AddGrade(1, 6);

            // Assert
            var addedGrade = student.Grades.FirstOrDefault();
            Assert.AreEqual(6, addedGrade);
        }

        [Test]
        public void GetStudent_ExistingStudentId_ReturnsStudent()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "John Doe" };
            studentRepository.AddStudent(student);

            // Act
            var retrievedStudent = studentRepository.GetStudent(1);

            // Assert
            Assert.AreEqual(student, retrievedStudent);
        }

        [Test]
        public void GetStudent_NonExistingStudentId_ReturnsNull()
        {
            // Act
            var retrievedStudent = studentRepository.GetStudent(1);

            // Assert
            Assert.IsNull(retrievedStudent);
        }

    }
}