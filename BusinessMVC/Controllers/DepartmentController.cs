using Microsoft.AspNetCore.Mvc;

namespace BusinessMVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
