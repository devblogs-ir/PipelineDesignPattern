using Dumpify;

namespace PipelineDesignPattern;

/// <summary>
/// Pipeline methods are defined here.
/// </summary>
public class LoginPipeLine
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        "Start Authentication".Dump("Authorising");

        if (httpContext.IP is "164.215.56.0")
        {
            throw new InvalidIPException("You are not eligible to login.");
        }

        "Eligible".Dump("Login successful!");

        action(httpContext);

    }


    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            action(httpContext);
        }
        catch (InvalidIPException e)
        {
            e.Message.Dump();
        }
        catch (Exception ex)
        {
            ex.Message.Dump();
        }
    }
}
