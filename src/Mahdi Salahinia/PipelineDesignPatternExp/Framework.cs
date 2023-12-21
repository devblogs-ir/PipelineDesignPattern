using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PipelineDesignPatternExp
{
    public class Framework
    {
        public void Authentication(HttpContext httpContext, Action<HttpContext> action)
        {
            "Start authenticate user".Dump();

            var ips = new CountryIp();

            if (ips.IranIps.Contains(httpContext.IpAddress))
            {
                "Access Denied".Dump();
            }
            else
                action(httpContext);

            "End of authenticate user".Dump();
        }

        public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
        {
            "Start ExceptionHandling pipe".Dump();
            try
            {
                action(httpContext);
            }
            catch (Exception e)
            {
                e.Message.Dump();
                throw;
            }
            "End ExceptionHandling pipe".Dump();
        }
    }
}
