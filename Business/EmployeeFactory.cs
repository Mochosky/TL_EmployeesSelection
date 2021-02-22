using Infrastructure;

namespace Business
{
    public class EmployeeFactory
    {
        public static IEmployee GetInstance(IEmployeeBase employeeBase)
        {
            return employeeBase.contractTypeName == "HourlySalaryEmployee"
                ? (IEmployee)new HourlyPayment(employeeBase)
                : (IEmployee)new MonthlyPayment(employeeBase);
        }
    }
}
