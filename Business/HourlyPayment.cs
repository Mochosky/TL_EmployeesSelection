using Infrastructure;

using System;
using System.Collections.Generic;
using System.Text;


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
