using ASP.NETCORE_ASSIGNMENT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NETCORE_ASSIGNMENT.Controllers
{
    public class HomeController : Controller
    {
        public String Indexs()
        {
            return "Welcome to ASP.NET Core MVC";
        }

        public String About()
        {
            return "this is about page";
        }

        public String Contact()
        {
            return "Contact us at support@test.com";
        }

        public IActionResult ResultIndex()
        {
            return View();
        }

        public IActionResult DynamicTitles(String title)
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult CheckAge(String age)
        {
            ViewData["age"] = age;
            return View();
        }

        public IActionResult List()
        {
            ViewData["student"] = new List<string>
            { "Ram","Sita","Laxman"};
            return View();
        }

    }
}
