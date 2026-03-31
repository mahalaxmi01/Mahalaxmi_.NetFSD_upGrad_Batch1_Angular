using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE_ASSIGNMENT.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String Profile()
        {
            return "profile";
        }

        public IActionResult Details(String name,int age)
        {
            ViewData["name"] = name;
            ViewData["age"] = age;
            return View();
        }

        public IActionResult StudentDetails(String name, int age)
        {
            ViewData["name"] = "john";
            ViewData["age"] = 25;
            return View();
        }

    }
}
