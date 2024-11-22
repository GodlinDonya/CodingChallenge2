using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Exceptions
{
    internal class PolicyNotFoundException:Exception
    {
        public PolicyNotFoundException()
        {

        }
        public PolicyNotFoundException(string msg) : base(msg)
        {

        }
    }
}
