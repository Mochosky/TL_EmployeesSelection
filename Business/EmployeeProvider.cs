using Infrastructure;

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeBaseProvider _employeeBaseProvider;

        public EmployeeProvider(IEmployeeBaseProvider employeeBaseProvider)
        {
            _employeeBaseProvider = employeeBaseProvider;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IEmployee>> GetEmployeeListAsync(int? id = null)
        {
            return (await _employeeBaseProvider.GetEmployeeBaseListAsync(id)).Select(e => EmployeeFactory.GetInstance(e));
        }
    }
}
