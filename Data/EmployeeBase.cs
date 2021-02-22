using Infrastructure;

using System;

namespace Data
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
