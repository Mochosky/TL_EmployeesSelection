using Infrastructure;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace TrueLogicTest.Controllers
{
    public class EmployeesInfoController : Controller
    {
        private readonly IEmployeeBaseProvider _employeeBaseProvider;
        private readonly IEmployeeProvider _employeeProvider;

        public EmployeesInfoController(IEmployeeBaseProvider employeeBaseProvider, IEmployeeProvider employeeProvider)
        {
            _employeeBaseProvider = employeeBaseProvider;
            _employeeProvider = employeeProvider;
        }

        public async Task<ViewResult> EmployeeList(int? employeeId)
        {
            return View(await _employeeProvider.GetEmployeeListAsync(employeeId));
        }
    }
}
