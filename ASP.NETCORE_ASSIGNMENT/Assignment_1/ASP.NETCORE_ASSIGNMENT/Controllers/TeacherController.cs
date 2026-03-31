using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE_ASSIGNMENT.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String Details()
        {
            return "details";
        }

        public IActionResult Employee_Details(string name,int salary,string dept)
        {
            ViewData["name"] = name;
            ViewData["salary"] = salary;
            ViewData["dept"] = dept;
            return View();
        }
    }
}
