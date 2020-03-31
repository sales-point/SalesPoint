using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Attributes
{
    public class LoggerAttribute : System.Attribute
    {
        public bool Flag;
        public LoggerAttribute()
        {
        }

        public LoggerAttribute(bool flag)
        {
            Flag = flag;
        }
    }
}
