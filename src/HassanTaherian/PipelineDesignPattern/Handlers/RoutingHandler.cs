using Dumpify;
using System;

namespace PipelineDesignPattern.Handlers;
public class RoutingHandler : BaseHandler
{
    public override void Handle(HttpContext httpContext)
    {
        "Start Routing".Dump();
        next?.Invoke(httpContext);
    }
}
