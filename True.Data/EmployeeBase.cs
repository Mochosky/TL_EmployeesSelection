using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using True.Infrastructure;

namespace True.Data
{
    public class EmployeeBase : IEmployeeBase
    {
        public string contractTypeName
        {
            get; set;
        }

        public decimal hourlySalary
        {
            get; set;
        }

        public int id
        {
            get; set;
        }

        public decimal monthlySalary
        {
            get; set;
        }

        public string name
        {
            get; set;
        }

        public string roleDescription
        {
            get; set;
        }

        public int roleId
        {
            get; set;
        }

        public string roleName
        {
            get; set;
        }
    }
}
