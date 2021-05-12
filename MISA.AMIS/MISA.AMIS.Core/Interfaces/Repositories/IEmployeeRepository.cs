using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface Employee repository
    /// </summary>
    /// CreatedBy: dvtrung
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Filter by name or employee code and get in range
        /// </summary>
        /// <param name="fromIndex">int</param>
        /// <param name="numberOfRecords">int</param>
        /// <param name="filter">string</param>
        /// <returns>List of employees</returns>
        /// CreatedBy: dvtrung
        IEnumerable<Employee> FilterAndGetInRange(int fromIndex, int numberOfRecords, string filter);
        /// <summary>
        /// count number of employees has code or name contains filter string
        /// </summary>
        /// <param name="filter">string</param>
        /// <returns>number of employees</returns>
        /// CreatedBy: dvtrung
        int CountNumberOfEmployeesFilter(string filter);
    }

}
