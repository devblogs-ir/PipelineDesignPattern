using Dumpify;


namespace PipelineProject.ClassLib;

public class Framework
{
    public void IPAuthentication(HttpContext context, Action<HttpContext> next)
    {
        "check your IP Address".Dump();
        if (string.Compare(context.IP, "192.168.0.130", StringComparison.OrdinalIgnoreCase) == 0)
        {
            throw new CheckBanndIPAddress(context.IP);
        }
        else
            next(context);

        "End of checking IP address".Dump();
    }

    public void ExceptionHandling(HttpContext context, Action<HttpContext> next)
    {
        "Start ExceptionHandling ".Dump();
        try
        {
            next(context);
        }
        catch (CheckBanndIPAddress e)
        {
            e.Message.Dump();
        }
        "End ExceptionHandling ".Dump();
    }
}

