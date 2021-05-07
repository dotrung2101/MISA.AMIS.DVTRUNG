using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.CustomAttributes
{
    public class MISARequiredNotNull : MISARequired
    {
        public MISARequiredNotNull(string msg) : base(msg)
        {

        }
    }
}
