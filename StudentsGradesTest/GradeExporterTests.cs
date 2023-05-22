using NUnit.Framework;
using StudentsGrades.Classes;
using StudentsGrades;
using System;
using System.Collections.Generic;
using System.IO;

[TestFixture]
public class GradeExporterTests
{
    private GradeExporter gradeExporter;

    [SetUp]
    public void SetUp()
    {
        gradeExporter = new GradeExporter();
    }

    [Test]
    public void ExportGrades_WritesCorrectDataToFile()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student { Id = 1, Name = "John", Grades = new List<int> { 3, 4, 5 } },
            new Student { Id = 2, Name = "Jane", Grades = new List<int> { 4, 5, 6 } }
        };
        var filePath = Const.FilePath;

        // Act
        gradeExporter.ExportGrades(students, filePath);

        // Assert
        var lines = File.ReadAllLines(filePath);
        Assert.AreEqual(2, lines.Length);

        var johnData = lines[0].Split(',');
        Assert.AreEqual("1", johnData[0]);
        Assert.AreEqual("John", johnData[1]);
        Assert.AreEqual("4", johnData[2]);

        var janeData = lines[1].Split(',');
        Assert.AreEqual("2", janeData[0]);
        Assert.AreEqual("Jane", janeData[1]);
        Assert.AreEqual("5", janeData[2]);
    }

    [Test]
    public void ExportGrades_ThrowsIOExceptionAndPrintsErrorMessage()
    {
        // Arrange
        var students = new List<Student>
    {
        new Student { Id = 1, Name = "John", Grades = new List<int> { 4, 5, 6 } }
    };
        var invalidFilePath = "invalidpath/" + Const.FilePath; // Provide a non-existent directory path

        // Assert
        Assert.Throws<DirectoryNotFoundException>(() =>
        {
            // Act
            gradeExporter.ExportGrades(students, invalidFilePath);
        });
    }
}
