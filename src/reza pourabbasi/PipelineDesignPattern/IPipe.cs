namespace PipelineDesignPattern;
public interface IPipe
{
    RequestDelegate? _next {  set; }
    Task HandleAsync(HttpContext httpContext);
}