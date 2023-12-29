﻿
using Dumpify;

namespace PipelineDesignPattern;

public class ExceptionHandlingPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        "starting ExceptionHandling".Dump();
        try
        {
            if (_next != null) _next(httpContext);
        }
        catch (Exception ex)
        {
            ex.Message.Dump();
        }
        "End ExceptionHandling".Dump();

    }
}
