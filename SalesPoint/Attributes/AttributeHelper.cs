using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SalesPoint.Attributes
{
    public static class AttributeHelper
    {
        public static object GetAttribute(MemberInfo t)
        {
            LoggerAttribute LogAttribute =
                (LoggerAttribute)Attribute.GetCustomAttribute(t, typeof(LoggerAttribute));

            return LogAttribute.Flag;
        }
    }
}
