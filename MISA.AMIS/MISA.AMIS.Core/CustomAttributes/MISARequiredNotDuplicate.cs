using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.CustomAttributes
{
    public class MISARequiredNotDuplicate : MISARequired
    {
        public MISARequiredNotDuplicate(string msg) : base(msg)
        {

        }
    }
}
