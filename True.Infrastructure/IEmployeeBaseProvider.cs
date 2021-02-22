using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True.Infrastructure
{
    public interface IEmployeeBaseProvider
    {
        IEnumerable<IEmployeeBase> GetEmployeeBaseList(int? id = null);
    }
}
