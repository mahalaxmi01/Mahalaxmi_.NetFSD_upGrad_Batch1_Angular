using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE_ASSIGNMENT.Controllers
{
    public class MathController : Controller
    {
        public int Add(int a,int b)
        {
            return a+b;
        }
        public int multiply(int a, int b)
        {
            return a * b;
        }

    }
}
