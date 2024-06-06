using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Exceptions
{
    public class AutomationException:Exception
    {
        public AutomationException(string message) : base(message) { }
    }
}
