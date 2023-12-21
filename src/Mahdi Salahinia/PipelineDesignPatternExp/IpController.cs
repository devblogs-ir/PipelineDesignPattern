using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp
{
    public class IpController
    {
        public void GetMyIp(HttpContext httpContext)
        {
            $"My Ip is {httpContext.IpAddress}".Dump();
        }
    }
}
