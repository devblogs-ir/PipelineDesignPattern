using Dumpify;
using PipelineDesignPattern.Exceptions;

namespace PipelineDesignPattern.Pipes;

public class ExceptionHandlerMiddleware(Action<Context> next) : Middleware(next)
{
    public override void Handle(Context context)
    {
        try
        {
            "ExceptionHandling Started".Dump();
            _next.Invoke(context);
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
}
