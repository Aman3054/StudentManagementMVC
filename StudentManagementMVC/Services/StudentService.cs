using System.ComponentModel.DataAnnotations;
using StudentManagementMVC.DataAccess;
using StudentManagementMVC.Helpers;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Services;

public class StudentService
{
    private readonly StudentEfRepository _efRepository;
    private readonly StudentAdoRepository _adoRepository;

    public StudentService(StudentEfRepository efRepository, StudentAdoRepository adoRepository)
    {
        _efRepository = efRepository;
        _adoRepository = adoRepository;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _efRepository.GetStudentsAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _efRepository.GetByIdAsync(id);
    }

    public async Task<(bool Success, string Message)> AddStudentAsync(Student student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
            return (false, "Name is required.");
        if (string.IsNullOrWhiteSpace(student.Email))
            return (false, "Email is required.");
        if (!new EmailAddressAttribute().IsValid(student.Email))
            return (false, "Please enter a valid email address.");
        if (student.Age < 18 || student.Age > 64)
            return (false, "Age must be between 18 and 64.");

        await _efRepository.AddStudentAsync(student);
        BackgroundLogger.LogStudentAdded(student.Name);
        return (true, "Student added successfully.");
    }

    public async Task<(bool Success, string Message)> UpdateStudentAsync(Student student)
    {
        var existing = await _efRepository.GetByIdAsync(student.StudentId);
        if (existing == null)
            return (false, "Student not found.");

        if (string.IsNullOrWhiteSpace(student.Name))
            return (false, "Name is required.");
        if (string.IsNullOrWhiteSpace(student.Email))
            return (false, "Email is required.");
        if (!new EmailAddressAttribute().IsValid(student.Email))
            return (false, "Please enter a valid email address.");
        if (student.Age < 18 || student.Age > 64)
            return (false, "Age must be between 18 and 64.");

        await _efRepository.UpdateStudentAsync(student);
        return (true, "Student updated successfully.");
    }

    public async Task<(bool Success, string Message)> DeleteStudentAsync(int id)
    {
        var student = await _efRepository.GetByIdAsync(id);
        if (student == null)
            return (false, "Student not found.");

        await _efRepository.DeleteStudentAsync(student);
        return (true, "Student deleted successfully.");
    }

    public int GetStudentCount()
    {
        return _adoRepository.GetStudentCount();
    }

    public int GetActiveStudentsCount()
    {
        return _adoRepository.GetActiveStudentsCount();
    }
}
