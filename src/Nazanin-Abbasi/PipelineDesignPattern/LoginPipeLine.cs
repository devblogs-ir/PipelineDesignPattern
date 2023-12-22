using Dumpify;

namespace PipelineDesignPattern
{
    /// <summary>
    /// Pipeline methods are defined here.
    /// </summary>
    public class LoginPipeLine
    {
        public void Authentication(HttpContext httpContext, Action<HttpContext> function)
        {
            "Start Authentication".Dump();

            if (httpContext.IP == 1)
            {
                throw new Exception("You are not eligible to login.");
            }
            else
            {
                "Eligible".Dump("Login successful!");

                function(httpContext);
            }
        }


        public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> function)
        {
            try
            {
                function(httpContext);
            }
            catch (Exception ex)
            {
                "Exception".Dump(ex.Message);
            }
        }
    }
}
