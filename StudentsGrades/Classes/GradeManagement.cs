using StudentsGrades.Interfaces;
using StudentsGrades;
using System;
using StudentsGrades.Classes;
using NLog;

public class GradeManagement : IGradeManagement
{
    private readonly static Logger logger = LogManager.GetCurrentClassLogger();
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

    public void AddNewStudent(string name, int id)
    {
        var student = new Student { Name = name, Id = id };

        try
        {
            studentRepository.AddStudent(student);
        }
        catch (Exception ex)
        {
            logger.Error(ex);

            Console.WriteLine(Const.AddStudentError);
        }
    }

    public void AddGrade(int studentId, int grade)
    {
        try
        {
            studentRepository.AddGrade(studentId, grade);
        }
        catch (Exception ex)
        {
            logger.Error(ex);

            Console.WriteLine(Const.AddGradesError);
        }
    }

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
            logger.Error(ex);

            Console.WriteLine(Const.CalcAverageGradeError);
            return 0;
        }
    }

    public void ExportGrades(string filePath)
    {
        var students = studentRepository.GetStudents();

        try
        {
            gradeExporter.ExportGrades(students, filePath);
        }
        catch (Exception ex)
        {
            logger.Error(ex);

            Console.WriteLine(Const.ExportGradesError);
        }
    }
}