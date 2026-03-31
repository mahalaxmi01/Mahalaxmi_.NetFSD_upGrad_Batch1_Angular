using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_2.Data;
using Assignment_2.Models;


namespace Assignment_2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Assignment 1: Basics
        public IActionResult Welcome()
        {
            return Content("Welcome to Student Page");
        }

        public IActionResult Details()
        {
            return Content("Student Details Page");
        }

        public IActionResult GetStudent(int id)
        {
            return Content($"Student ID is {id}");
        }

        // Assignment 3: Pass Student object to view
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // Assignment 4: ViewBag and ViewData
        public IActionResult StudentInfo()
        {
            ViewBag.StudentName = "MahaLaxmi";
            ViewData["StudentAge"] = 22;
            return View();
        }

        // Assignment 7 & 8: Create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Student added successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Student updated successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Student deleted successfully";
            }

            return RedirectToAction("Index");
        }
        public IActionResult ShowStudent()
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Sai Sita MahaLaxmi",
                Age = 22,
                Email = "mahalaxmi@gmail.com"
            };

            return View(student);
        }
    }
}
