using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IEmployee : IEmployeeBase
    {
        decimal annualSalary
        {
            get;
        }
    }
}
