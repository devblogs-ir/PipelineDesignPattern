using Dumpify;
using PipelineDesignPattern.Exceptions;

namespace PipelineDesignPattern.Pipes;

public class AuthorizationMiddleware(Action<Context> next) : Middleware(next)
{
    public override void Handle(Context context)
    {
        "Authorization Started".Dump();
        if (context.Ip.StartsWith("192.168"))
            throw new ForbiddenAccessException("Sorry You're Not Allowed to use this service");

        _next.Invoke(context);
        "Authorization End".Dump();
    }
}
