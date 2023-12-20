using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineProject.ClassLib
{
    public class CheckBanndIPAddress:Exception
    {
        public CheckBanndIPAddress(string ip) 
            : base(string.Format("{0} this ip address is bannd", ip)) 
        {
        }

        public CheckBanndIPAddress(string message, Exception Exception) 
            : base(message, Exception) 
        {
        }

    }
}
