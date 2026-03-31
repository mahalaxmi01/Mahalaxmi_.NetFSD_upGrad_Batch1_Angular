using Microsoft.AspNetCore.Mvc;
using User_Management_System_MVC.Models;
using User_Management_System_MVC.ViewModel;

namespace User_Management_System_MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Temporary storage instead of database
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        // Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register POST
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            // Check duplicate email
            var existingUser = users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(user);
            }

            user.Id = nextId++;
            users.Add(user);

            TempData["SuccessMessage"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }

        // Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("Profile");
        }

        // Profile GET
        [HttpGet]
        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            UserViewModel vm = new UserViewModel
            {
                Name = user.Name,
                Email = user.Email
            };

            return View(vm);
        }

        // Edit GET
        [HttpGet]
        public IActionResult Edit()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // Edit POST
        [HttpPost]
        public IActionResult Edit(User model)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check email duplicate for other users
            var emailExists = users.Any(u => u.Email == model.Email && u.Id != user.Id);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(model);
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.ConfirmPassword = model.ConfirmPassword;

            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("Profile");
        }

        // Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
