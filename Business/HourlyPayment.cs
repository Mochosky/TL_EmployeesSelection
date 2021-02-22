using Infrastructure;

namespace Business
{
    public class HourlyPayment : Employee
    {
        public override decimal annualSalary => 120 * _employeeBase.hourlySalary * 12;

        public HourlyPayment(IEmployeeBase employeeBase)
            : base(employeeBase)
        {
        }
    }
}
