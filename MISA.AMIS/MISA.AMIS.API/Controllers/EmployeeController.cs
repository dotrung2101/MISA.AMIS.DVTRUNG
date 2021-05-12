using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Filt and get employees in range
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns>
        ///200: if has more than one employee
        ///400: if not
        /// </returns>
        /// CreatedBy: dvtrung
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
        /// <summary>
        /// Get excel file include all employees
        /// </summary>
        /// <returns>
        ///200: if has excel file
        /// </returns>
        [HttpGet("export")]
        public IActionResult Export()
        {
            var stream = _employeeService.ExportExcel();
            string excelName = $"Danh-sach-nhan-vien-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

        }
    }
}
