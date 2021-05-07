using MISA.AMIS.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        [MISARequiredNotNull("Mã đơn vị không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Mã đơn vị đã tồn tại trong hệ thống!!!")]
        public string DepartmentCode { get; set; }

        [MISARequiredNotNull("Tên đơn vị không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Tên đơn vị đã tồn tại trong hệ thống!!!")]
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
