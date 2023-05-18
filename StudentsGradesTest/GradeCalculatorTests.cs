using NUnit.Framework;
using StudentsGrades;
using StudentsGrades.Classes;
using StudentsGrades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesTests
{
    [TestFixture]
    public class GradeCalculatorTests
    {
        private GradeCalculator gradeCalculator;

        [SetUp]
        public void Setup()
        {
            gradeCalculator = new GradeCalculator();
        }

        [Test]
        public void CalculateAverageGrade_NoGrades_ReturnsZero()
        {
            // Arrange
            var student = new Student();

            // Act
            var result = gradeCalculator.CalculateAverageGrade(student);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalculateAverageGrade_GradesExist_ReturnsAverage()
        {
            // Arrange
            var student = new Student();
            student.Grades = new List<int> { 5, 6, 4 };

            // Act
            var result = gradeCalculator.CalculateAverageGrade(student);

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
