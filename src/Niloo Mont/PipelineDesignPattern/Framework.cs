using Dumpify;

namespace PipelineDesignPattern
{
    public class Framework
    {
        public void ExceptionHandling(HttpContext httpContext,Action<HttpContext> function)
        {
            $"ExceptionHandling Started for {httpContext.IP}".Dump();
            function(httpContext);
            $"ExceptionHandling Ended for {httpContext.IP}".Dump();
        }

        public void Authentication(HttpContext httpContext, Action<HttpContext> function)
        {
            try
            {
                if (httpContext.IP == "Iran")
                    throw new BannedIPException(httpContext.IP);
                else
                    function(httpContext);
            }
            catch (BannedIPException ex)
            {
                ex.Message.Dump();
            }
        }
    }
}
