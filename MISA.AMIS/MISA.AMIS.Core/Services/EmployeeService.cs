using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public IEnumerable<Employee> FilterAndGetInRange(int pageIndex, int pageSize, string filter)
        {
            if(pageIndex <= 0 || pageSize <= 0)
            {
                return null;
            }

            if(filter == null)
            {
                filter = "";
            }

            int fromIndex = (pageIndex - 1) * pageSize;

            return _employeeRepository.FilterAndGetInRange(fromIndex, pageSize, filter);
        }

        public int CountNumberOfEmployeesFilter(string filter)
        {
            if (filter == null)
            {
                filter = "";
            }
            return _employeeRepository.CountNumberOfEmployeesFilter(filter);
        }

        public Stream ExportExcel()
        {
            var list = _employeeRepository.GetAll().ToList<Employee>();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

            // set độ rộng col
            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 10;
            workSheet.Column(5).Width = 15;
            workSheet.Column(6).Width = 30;
            workSheet.Column(7).Width = 30;
            workSheet.Column(8).Width = 15;
            workSheet.Column(9).Width = 30;


            using (var range = workSheet.Cells["A1:I1"])
            {
                range.Merge = true;
                range.Value = "DANH SÁCH NHÂN VIÊN";
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            // style cho excel.
            workSheet.Cells[3, 1].Value = "STT";
            workSheet.Cells[3, 2].Value = "Mã nhân viên";
            workSheet.Cells[3, 3].Value = "Tên nhân viên";
            workSheet.Cells[3, 4].Value = "Giới tính";
            workSheet.Cells[3, 5].Value = "Ngày sinh";
            workSheet.Cells[3, 6].Value = "Chức danh";
            workSheet.Cells[3, 7].Value = "Tên đơn vị";
            workSheet.Cells[3, 8].Value = "Số tài khoản";
            workSheet.Cells[3, 9].Value = "Tên ngân hàng";

            using (var range = workSheet.Cells["A3:I3"])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                range.Style.Font.Bold = true;
                range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }


            
            // đổ dữ liệu từ list vào.
            for(int i = 0; i < list.Count(); i++)
            {
                workSheet.Cells[i + 4, 1].Value = i + 1;
                workSheet.Cells[i + 4, 2].Value = list[i].EmployeeCode;
                workSheet.Cells[i + 4, 3].Value = list[i].FullName;
                workSheet.Cells[i + 4, 4].Value = list[i].GenderName;
                workSheet.Cells[i + 4, 5].Value = list[i].DateOfBirth?.ToString("dd/MM/yyyy");
                workSheet.Cells[i + 4, 6].Value = list[i].PositionName;
                workSheet.Cells[i + 4, 7].Value = list[i].DepartmentName;
                workSheet.Cells[i + 4, 8].Value = list[i].BankAccount;
                workSheet.Cells[i + 4, 9].Value = list[i].BankName;

                using (var range = workSheet.Cells[i + 4, 1, i + 4, 9])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
            }

            package.Save();
            stream.Position = 0;
            return package.Stream;
        }
    }
}
