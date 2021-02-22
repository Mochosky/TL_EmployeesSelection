using Infrastructure;

using System;
using System.Collections.Generic;
using System.Text;


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
