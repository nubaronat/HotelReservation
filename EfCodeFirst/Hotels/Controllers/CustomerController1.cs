using Microsoft.AspNetCore.Mvc;

namespace Hotels.Controllers
{
    public class CustomerController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
