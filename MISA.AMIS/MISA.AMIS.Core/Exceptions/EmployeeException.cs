using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Exceptions
{
    public class EmployeeException : Exception
    {
        private Object _ExceptionData;

        public Object ExceptionData
        {
            get
            {
                return this._ExceptionData;
            }
        }

        public EmployeeException(Object data) : base()
        {
            _ExceptionData = data;
        }
    }
}
