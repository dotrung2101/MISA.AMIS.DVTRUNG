using MISA.AMIS.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        [MISARequiredNotNull("Mã nhân viên không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Mã nhân viên đã tồn tại trong hệ thống!!!")]
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }

        [MISARequiredNotNull("Chứng minh thư/Căn cước công dân không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Chứng minh thư/Căn cước công dân đã tồn tại trong hệ thống!!!")]
        public string IdentifyNumber { get; set; }
        public DateTime? DateOfIN { get; set; }
        public string PlaceOfIN { get; set; }

        [MISARequiredNotNull("Email không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Email đã tồn tại trong hệ thống!!!")]
        public string Email { get; set; }

        [MISARequiredNotNull("Số điện thoại không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Số điện thoại đã tồn tại trong hệ thống!!!")]
        public string PhoneNumber { get; set; }
        public string PositionName { get; set; }

        [MISARequiredNotNull("Đơn vị không được phép để trống!!!")]
        public Guid? DepartmentId { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string PhoneStatic { get; set; }

        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
