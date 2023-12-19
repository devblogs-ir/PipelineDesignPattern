namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (httpContext is null || httpContext.IP == "iran")
            throw new InvalidIPException("invalid IP");

        action(httpContext);
    }
    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            action(httpContext);
        }
        catch (InvalidIPException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}