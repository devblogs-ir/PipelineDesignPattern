using Dumpify;

namespace PipelineDesignPattern;
    public class Framework
    {
        public void ExceptionHandling(HttpContext httpContext,Action<HttpContext> function)
        {
            try
            {
                if (httpContext.IP is "Iran")
                    throw new BannedIPException(httpContext.IP);
                else
                    function(httpContext);
            }
            catch (BannedIPException ex)
            {
                ex.Message.Dump();
            }
        }

        public void Authentication(HttpContext httpContext, Action<HttpContext> function)
        {
            $"Authentication Started for {httpContext.IP}".Dump();
            function(httpContext);
            $"Authentication Ended for {httpContext.IP}".Dump();            
        }
    }
