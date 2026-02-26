using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.DataAccess;

public class StudentEfRepository
{
    private readonly ApplicationDbContext _context;

    public StudentEfRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var existing = await _context.Students.FindAsync(student.StudentId);
        if (existing == null)
            throw new InvalidOperationException($"Student with id {student.StudentId} not found.");

        existing.Name = student.Name;
        existing.Email = student.Email;
        existing.Age = student.Age;
        existing.IsActive = student.IsActive;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }
}
