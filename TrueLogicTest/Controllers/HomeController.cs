using Microsoft.AspNetCore.Mvc;

namespace TrueLogicTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("EmployeeList", "EmployeesInfo");
        }
    }
}
