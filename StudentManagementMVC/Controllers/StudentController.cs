using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.Models;
using StudentManagementMVC.Services;

namespace StudentManagementMVC.Controllers;

public class StudentController : Controller
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _studentService.GetStudentsAsync();
        return View(students);
    }

    public async Task<IActionResult> Details(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
            return NotFound();
        return View(student);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Student());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        var (success, message) = await _studentService.AddStudentAsync(student);
        if (!success)
        {
            TempData["Error"] = message;
            return View(student);
        }
        TempData["Success"] = message;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
            return NotFound();
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        var (success, message) = await _studentService.UpdateStudentAsync(student);
        if (!success)
        {
            TempData["Error"] = message;
            return View(student);
        }
        TempData["Success"] = message;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
            return NotFound();
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var (success, message) = await _studentService.DeleteStudentAsync(id);
        if (!success)
        {
            TempData["Error"] = message;
            return RedirectToAction(nameof(Index));
        }
        TempData["Success"] = message;
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Reports()
    {
        var totalStudents = _studentService.GetStudentCount();
        var activeStudents = _studentService.GetActiveStudentsCount();
        ViewBag.TotalStudents = totalStudents;
        ViewBag.ActiveStudents = activeStudents;
        return View();
    }
}
