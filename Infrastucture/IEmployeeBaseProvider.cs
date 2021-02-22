using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IEmployeeBaseProvider
    {
        /// <summary>
        /// Async method to get the Base Employee list.
        /// </summary>
        /// <param name="id">A valid nullable <see cref="System.Int32"/> with the Employee Id to query.</param>
        /// <returns>A <see cref="IEnumerable{IEmployeeBase}"/> with the Base Employee list that matches the Id or the whole Employee list.</returns>
        Task<IEnumerable<IEmployeeBase>> GetEmployeeBaseListAsync(int? id = null);
    }
}
