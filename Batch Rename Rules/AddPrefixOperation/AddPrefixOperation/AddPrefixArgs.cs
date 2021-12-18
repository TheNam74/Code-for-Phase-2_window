using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace AddPrefixOperation
{
    public class AddPrefixArgs : StringArgs
    {
        public string Prefix { get; set; }
    }
}
