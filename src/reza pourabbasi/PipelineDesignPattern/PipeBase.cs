
namespace PipelineDesignPattern;
public abstract class PipeBase : IPipe
{
    public RequestDelegate? _next { get; set; }

    public abstract Task HandleAsync(HttpContext httpContext);
}