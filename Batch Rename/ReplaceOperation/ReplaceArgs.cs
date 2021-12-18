using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace ReplaceOperation
{
    class ReplaceArgs:StringArgs
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}
