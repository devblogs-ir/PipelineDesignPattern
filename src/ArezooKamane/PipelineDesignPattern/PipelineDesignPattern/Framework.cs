using Dumpify;

namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext context, Action<HttpContext> next)
    {
        "Start authenticate user".Dump();

        if (IpRangeChecker.IpRangeCheck(context.IP))
            throw new IpNotAllowedException(ip: context.IP);
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
        catch (IpNotAllowedException e)
        {
            e.Message.Dump();
        }
        catch (Exception e)
        {
            e.Message.Dump();
        }

        "End ExceptionHandling pipe".Dump();
    }
}

