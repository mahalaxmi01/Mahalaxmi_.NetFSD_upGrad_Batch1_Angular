using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE_ASSIGNMENT.Controllers
{
    public class ProductController : Controller
    {
        public String GetProduct(int id)
        {
            return $"Product Id is: {id}";
        }
    }
}
