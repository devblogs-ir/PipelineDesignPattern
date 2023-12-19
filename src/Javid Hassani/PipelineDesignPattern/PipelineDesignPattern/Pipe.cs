using Dumpify;
using PipelineDesignPattern.Exceptions;

namespace PipelineDesignPattern;

public class Pipe
{
    public void ExceptionHandling(Context context, Action<Context> action)
    {
        try
        {
            "ExceptionHandling Started".Dump();

            action(context);

            "ExceptionHandling End".Dump();
        }
        catch (Exception ex)
        {
            int statusCode = ex switch
            {
                ForbiddenAccessException => 406,
                Exception => 500
            };

            $"Error {statusCode} : {ex.Message}".Dump();
        }
    }

    public void Authurization(Context context, Action<Context> action)
    {
        "Authorization Started".Dump();
        if (context.Ip.StartsWith("192.168"))
            throw new ForbiddenAccessException("Sorry You're Not Allowed to use this service");

        action(context);
        "Authorization End".Dump();
    }

    public void Cors(Context context, Action<Context> action)
    {
        "Start CORS".Dump();

        action(context);

        "End CORS".Dump();
    }
}
