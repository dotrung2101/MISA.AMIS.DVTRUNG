using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class EmployeeController : BaseController<Employee>
    {

        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository) : base(employeeService)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("paging")]
        public IActionResult FilterAndPaging(int pageIndex, int pageSize, string filter)
        {
            var employees = _employeeService.FilterAndGetInRange(pageIndex, pageSize, filter);

            var numberOfEmployees = _employeeService.CountNumberOfEmployeesFilter(filter);
            if(employees == null)
            {
                return NoContent();
            }
            else if(employees.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(new
                {
                    data = employees,
                    totalRecords = numberOfEmployees,
                });
            }
        }

    }
}
