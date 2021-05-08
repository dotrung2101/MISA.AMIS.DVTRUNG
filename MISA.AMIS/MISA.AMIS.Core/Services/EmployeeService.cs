using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {

        IEmployeeRepository _employeeRepository;
        IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        protected override void CustomValidate(Employee employee)
        {
            if(employee.DepartmentId == null)
            {
                return;
            }
            var department = _departmentRepository.GetById(employee.DepartmentId);
            if(department == null)
            {
                _listValidate.Add(new { devMsg = "Đơn vị không tồn tại trong hệ thống" });
            }
        }

        public IEnumerable<Employee> FilterAndGetInRange(int pageIndex, int pageSize, string fullName, Guid? departmentId)
        {
            if(pageIndex <= 0 || pageSize <= 0)
            {
                return null;
            }

            if(fullName == null)
            {
                fullName = "";
            }

            int fromIndex = (pageIndex - 1) * pageSize;

            return _employeeRepository.FilterAndGetInRange(fromIndex, pageSize, fullName, departmentId);
        }
    }
}
