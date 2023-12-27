namespace PipelineDesignPattern.Controllers;

public class Framework
{
    public void ExceptionHandeling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            Console.WriteLine($"Starting Exception Handeling... ({httpContext.IP})");
            action(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine($"Finish Exception Handeling.  ({httpContext.IP})");
        }
    }

    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (httpContext.IP.StartsWith("98."))
            throw new Exception("You are from Iran!");

        Console.WriteLine($"Starting Authentication...  ({httpContext.IP})");
        action(httpContext);
        Console.WriteLine($"Finish Authentication.  ({httpContext.IP})");
    }
}