using Dumpify;
using System;

namespace PipelineDesignPattern.Handlers;
public class RoutingHandler : BaseHandler
{
    private readonly (int Min, int Max) subRoutesNumberRange = (2, 3);
    public override void Handle(HttpContext httpContext)
    {
        "Start Routing".Dump();
        var requestedUrl = httpContext.Request.Url;
        var subRoutes = requestedUrl.Split('/');

        if (subRoutes.Length > subRoutesNumberRange.Max || subRoutes.Length < subRoutesNumberRange.Min)
        {
            throw new InvalidUrlFormatException(httpContext.Request.Url);
        }
        EndPoint endPoint = new()
        {
            ControllerName = subRoutes[0],
            ActionName = subRoutes[1],
            Parameter = subRoutes.Length == subRoutesNumberRange.Max ? subRoutes[subRoutesNumberRange.Max - 1] : null
        };

        httpContext.Request.EndPoint = endPoint;

        next?.Invoke(httpContext);
    }
}
