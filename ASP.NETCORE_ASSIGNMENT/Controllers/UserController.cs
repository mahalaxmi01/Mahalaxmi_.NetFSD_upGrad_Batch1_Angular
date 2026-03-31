using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE_ASSIGNMENT.Controllers
{
    public class UserController : Controller
    {
        public String Details(String name,int age)
        {
            return $"Name:'{name}' age:{age}";
        }
    }
}
