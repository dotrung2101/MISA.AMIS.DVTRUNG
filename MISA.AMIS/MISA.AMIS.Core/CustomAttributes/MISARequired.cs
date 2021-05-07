using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        protected string _Msg;

        public string Msg { get; }
        public MISARequired(string msg)
        {
            Msg = msg;
        }
    }
}
