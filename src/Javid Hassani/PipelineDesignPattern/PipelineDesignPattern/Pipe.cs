using Dumpify;
using PipelineDesignPattern.Exceptions;

namespace PipelineDesignPattern;

public class Pipe
{
    public static void ExceptionHandling(Context context, Action<Context> action)
    {
        try
        {
            "ExceptionHandling Started".Dump();

            action(context);

            "ExceptionHandling End".Dump();
        }
        catch (ForbiddenAccessException ex)
        {
            $"Error 403 : {ex.Message}".Dump();
        }
        catch (NotFoundException ex)
        {
            $"Error 404 : {ex.Message}".Dump();
        }
    }

    public static void Authurization(Context context, Action<Context> action)
    {
        "Authorization Started".Dump();
        if (context.Ip.StartsWith("192.168"))
            throw new ForbiddenAccessException("Sorry You're Not Allowed to use this service");

        action(context);
        "Authorization End".Dump();
    }

    public static void Cors(Context context, Action<Context> action)
    {
        "Start CORS".Dump();

        action(context);

        "End CORS".Dump();
    }
}
