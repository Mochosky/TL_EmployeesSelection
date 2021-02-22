using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True.Infrastructure
{
    public interface IEmployeeProvider
    {
        IEnumerable<IEmployee> GetEmployeeList(int? id = null);
    }
}
