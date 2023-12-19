
using System.Security.Authentication;

namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (httpContext.IP.Equals("iran", StringComparison.OrdinalIgnoreCase))
            throw new InvalidCredentialException("invalid IP");

        action(httpContext);
    }
    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            action(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}