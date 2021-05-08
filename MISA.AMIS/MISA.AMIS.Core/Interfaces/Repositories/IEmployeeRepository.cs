using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IEnumerable<Employee> FilterAndGetInRange(int fromIndex, int numberOfRecords, string fullName, Guid? departmentId);
    }
}
