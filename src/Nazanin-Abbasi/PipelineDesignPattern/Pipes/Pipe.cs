namespace PipelineDesignPattern.Pipelines;
public abstract class Pipe(Action<HttpContext> next)
{
    public Action<HttpContext> _next = next;

    public abstract void Handle(HttpContext httpContext);
}
