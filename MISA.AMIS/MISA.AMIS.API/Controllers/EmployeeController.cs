using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
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

        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("paging")]
        public IActionResult FilterAndPaging(int pageIndex, int pageSize, string fullName, Guid? departmentId)
        {
            var employees = _employeeService.FilterAndGetInRange(pageIndex, pageSize, fullName, departmentId);

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
                return Ok(employees);
            }
        }

    }
}
