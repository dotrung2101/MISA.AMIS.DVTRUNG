using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Services
{
    /// <summary>
    /// Interface Employee service
    /// </summary>
    /// CreatedBy: dvtrung
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Filter by name or employee code and get in range
        /// </summary>
        /// <param name="pageIndex">int</param>
        /// <param name="numberOfRecords">int</param>
        /// <param name="filter">string</param>
        /// <returns>List of employees</returns>
        /// CreatedBy: dvtrung
        IEnumerable<Employee> FilterAndGetInRange(int pageIndex, int numberOfRecords, string filter);
        /// <summary>
        /// count number of employees has code or name contains filter string
        /// </summary>
        /// <param name="filter">string</param>
        /// <returns>number of employees</returns>
        /// CreatedBy: dvtrung
        int CountNumberOfEmployeesFilter(string filter);
        /// <summary>
        /// get all employees in the table and build excel file
        /// </summary>
        /// <returns>Excel file</returns>
        /// CreatedBy: dvtrung
        Stream ExportExcel(); 
    }
}
