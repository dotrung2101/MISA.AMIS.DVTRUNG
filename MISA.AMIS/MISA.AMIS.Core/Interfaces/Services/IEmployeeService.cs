using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        IEnumerable<Employee> FilterAndGetInRange(int pageIndex, int numberOfRecords, string filter);
        int CountNumberOfEmployeesFilter(string filter);
    }
}
