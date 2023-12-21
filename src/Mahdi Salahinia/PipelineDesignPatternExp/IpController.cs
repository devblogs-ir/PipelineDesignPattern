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
        public void GetUserIp(HttpContext httpContext)
        {
            $"User Ip: {httpContext.IpAddress}".Dump();
        }
    }
}
