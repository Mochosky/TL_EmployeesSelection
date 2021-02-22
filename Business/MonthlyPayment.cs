using Infrastructure;

using System;
using System.Collections.Generic;
using System.Text;



namespace Business
{
    public class MonthlyPayment : Employee
    {
        public override decimal annualSalary => _employeeBase.monthlySalary * 12;

        public MonthlyPayment(IEmployeeBase employeeBase)
            : base(employeeBase)
        {
        }
    }
}
