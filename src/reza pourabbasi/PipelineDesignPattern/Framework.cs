namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (httpContext is null)
            throw new IPNotProvideException("ip is not provide");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

        action(httpContext);
    }
    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            action(httpContext);
        }
        catch (Exception ex) when (ex is IPNotProvideException)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is InvalidIPException)
        {
            Console.WriteLine(ex.Message);
        }
    }
}