using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class Framework
    {
        public void Authentication(HttpContext context, Action<HttpContext> next)
        {
            "Start authenticate user".Dump();
            if (string.Compare(context.IP, "iran", StringComparison.OrdinalIgnoreCase) == 0)
            {
                throw new IpNotAllowedException(ip: context.IP);
            }
            else
                next(context);

            "End of authenticate user".Dump();
        }

        public void ExceptionHandling(HttpContext context, Action<HttpContext> next)
        {
            "Start ExceptionHandling pipe".Dump();
            try
            {
                next(context);
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
