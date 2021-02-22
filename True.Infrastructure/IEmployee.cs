using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True.Infrastructure
{
    public interface IEmployee : IEmployeeBase
    {
        decimal annualSalary
        {
            get;
        }
    }
}
