using Dumpify;
namespace PipelineDesignPattern;


public class AuthenticationPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        "staring Authentication ".Dump();

        if (httpContext.IP.StartsWith("188"))
            throw new Exception($"The {httpContext.IP} Invalid Ip");
        else
            if (_next != null) _next(httpContext);

        "End Authentication".Dump();
    }
}
