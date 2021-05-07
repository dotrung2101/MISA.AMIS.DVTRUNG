using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Services;
using MISA.AMIS.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {

        IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
