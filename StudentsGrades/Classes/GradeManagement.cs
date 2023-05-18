using StudentsGrades.Interfaces;
using StudentsGrades;
using System;

public class GradeManagement
{
    private readonly IStudentRepository studentRepository;
    private readonly IGradeCalculator gradeCalculator;
    private readonly IGradeExporter gradeExporter;

    /// <summary>
    /// Initializes a new instance of the GradeManagement class.
    /// </summary>
    /// <param name="studentRepository">The repository used for accessing student data.</param>
    /// <param name="gradeCalculator">The calculator used for calculating grades.</param>
    /// <param name="gradeExporter">The exporter used for exporting grades.</param>
    public GradeManagement(
        IStudentRepository studentRepository,
        IGradeCalculator gradeCalculator,
        IGradeExporter gradeExporter)
    {
        this.studentRepository = studentRepository;
        this.gradeCalculator = gradeCalculator;
        this.gradeExporter = gradeExporter;
    }

    /// <summary>
    /// Adds a new student with the specified name and ID.
    /// </summary>
    /// <param name="name">The name of the student.</param>
    /// <param name="id">The ID of the student.</param>
    public void AddNewStudent(string name, int id)
    {
        var student = new Student { Name = name, Id = id };

        try
        {
            studentRepository.AddStudent(student);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding a new student: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a grade to the student with the specified ID.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <param name="grade">The grade to be added.</param>
    public void AddGrade(int studentId, int grade)
    {
        try
        {
            studentRepository.AddGrade(studentId, grade);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding a grade: {ex.Message}");
        }
    }

    /// <summary>
    /// Calculates the average grade for the student with the specified ID.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <returns>The average grade of the student.</returns>
    public decimal CalculateAverageGrade(int studentId)
    {
        var student = studentRepository.GetStudent(studentId);

        try
        {
            if (student != null)
            {
                return gradeCalculator.CalculateAverageGrade(student);
            }
            else
            {
                throw new ArgumentException("Student not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while calculating the average grade: {ex.Message}");
            return 0;
        }
    }

    /// <summary>
    /// Exports the grades of all students to the specified file path.
    /// </summary>
    /// <param name="filePath">The file path to export the grades to.</param>
    public void ExportGrades(string filePath)
    {
        var students = studentRepository.GetStudents();

        try
        {
            gradeExporter.ExportGrades(students, filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while exporting grades: {ex.Message}");
        }
    }
}