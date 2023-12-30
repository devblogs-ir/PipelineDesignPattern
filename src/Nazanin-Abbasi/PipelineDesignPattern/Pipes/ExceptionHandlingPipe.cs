using Dumpify;

namespace PipelineDesignPattern.Pipelines;

public class ExceptionHandlingPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        try
        {
            "Start ExceptionHandling...".Dump("ExceptionHandling");

            if (_next is not null) _next(httpContext);

        }
        catch (InvalidIPException ex)
        {
            ex.Message.Dump();
        }
    }
}