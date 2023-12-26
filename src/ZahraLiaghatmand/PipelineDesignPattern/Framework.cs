using System.Reflection;

namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        Console.WriteLine("starting Auth");
        if (httpContext is null)
            throw new IPNotProvideException("IP is not provided");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

        action(httpContext);
    }
    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        Console.WriteLine("starting except");
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
    public void EndpointHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        var parts = httpContext.Url.Split('/');
        var controllerClass = parts[1];
        var actionMethod = parts[2];
        var templateControllerName = $"PipelineDesignPattern.{controllerClass}Controller";
        var typeController = Type.GetType(templateControllerName);
        var instance = Activator.CreateInstance(typeController, new[] {httpContext});
        //var productsController = instance as ProductsController;
        MethodInfo method = typeController.GetMethod(actionMethod);
        method.Invoke(instance, null);


    }
}