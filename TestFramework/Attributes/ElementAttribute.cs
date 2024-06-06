using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public  class ElementAttribute: BaseValueAttribute
    {
        public ElementAttribute(string value) : base(value) { }
    }
}
