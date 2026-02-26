using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Range(18, 64, ErrorMessage = "Age must be between 18 and 64.")]
    public int Age { get; set; }

    public bool IsActive { get; set; }
}
