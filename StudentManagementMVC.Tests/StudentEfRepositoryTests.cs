using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudentManagementMVC.DataAccess;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Tests;

[TestFixture]
public class StudentEfRepositoryTests
{
    private static ApplicationDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new ApplicationDbContext(options);
    }

    [Test]
    public async Task AddStudent_ShouldAdd()
    {
        await using var context = CreateInMemoryContext();
        var repository = new StudentEfRepository(context);

        var student = new Student
        {
            Name = "Test Student",
            Email = "test@test.com",
            Age = 20,
            IsActive = true
        };

        await repository.AddStudentAsync(student);

        var list = await context.Students.ToListAsync();
        Assert.That(list, Has.Count.EqualTo(1));
        Assert.That(list[0].Name, Is.EqualTo("Test Student"));
        Assert.That(list[0].Email, Is.EqualTo("test@test.com"));
    }

    [Test]
    public async Task GetStudents_ShouldReturnList()
    {
        await using var context = CreateInMemoryContext();
        var repository = new StudentEfRepository(context);

        context.Students.Add(new Student { Name = "A", Email = "a@a.com", Age = 18, IsActive = true });
        context.Students.Add(new Student { Name = "B", Email = "b@b.com", Age = 19, IsActive = false });
        await context.SaveChangesAsync();

        var list = await repository.GetStudentsAsync();

        Assert.That(list, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task UpdateStudent_ShouldModify()
    {
        await using var context = CreateInMemoryContext();
        var repository = new StudentEfRepository(context);

        var student = new Student { Name = "Original", Email = "orig@test.com", Age = 21, IsActive = true };
        context.Students.Add(student);
        await context.SaveChangesAsync();

        student.Name = "Updated";
        student.Email = "updated@test.com";
        await repository.UpdateStudentAsync(student);

        var fromDb = await repository.GetByIdAsync(student.StudentId);
        Assert.That(fromDb, Is.Not.Null);
        Assert.That(fromDb!.Name, Is.EqualTo("Updated"));
        Assert.That(fromDb.Email, Is.EqualTo("updated@test.com"));
    }

    [Test]
    public async Task DeleteStudent_ShouldRemove()
    {
        await using var context = CreateInMemoryContext();
        var repository = new StudentEfRepository(context);

        var student = new Student { Name = "ToDelete", Email = "del@test.com", Age = 22, IsActive = true };
        context.Students.Add(student);
        await context.SaveChangesAsync();

        await repository.DeleteStudentAsync(student);

        var list = await context.Students.ToListAsync();
        Assert.That(list, Has.Count.EqualTo(0));
    }
}
