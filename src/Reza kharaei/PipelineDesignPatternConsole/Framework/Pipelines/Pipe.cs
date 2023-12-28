using PipelineDesignPatternConsole.Models;

namespace PipelineDesignPatternConsole.Framework.Pipelines;

public abstract class Pipe(Action<HttpContext> next)
{
    public Action<HttpContext> _next = next;

    public abstract void Handler(HttpContext httpContext);
}