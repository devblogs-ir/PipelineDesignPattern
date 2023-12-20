using Dumpify;

namespace PipeLineApp;

public class Framework
{
    public static void Authentication(HttpContext context, Action<HttpContext> action)
    {
        context.Ip.Dump("Starting Auth");
        if (context.Ip == "192.168.1.1") throw new Exception("you are from iran");
        action(context);
        "End Auth".Dump();
    }

    public static void ExceptionHandling(HttpContext context, Action<HttpContext> action)
    {
        try
        {
            action(context);
        }
        catch (Exception e)
        {
            "Exception Catch".Dump(e.Message);
        }
    }
}