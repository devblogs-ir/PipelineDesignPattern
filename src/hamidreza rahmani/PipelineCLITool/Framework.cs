using System.Reflection;


namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (httpContext is null)
            throw new IPNotProvideException("ip is not provide");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

        Console.WriteLine("Starting Authentication");

        action(httpContext);
    }

    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {

            Console.WriteLine("Starting ExceptionHandling");
            action(httpContext);
        }
        catch (IPNotProvideException ex)
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
        var userId = parts[3];

        var templateControllerName = $"PipelineDesignPattern.{controllerClass}Controller";
        var typeController = Type.GetType(templateControllerName);
        MethodInfo method = typeController.GetMethod(actionMethod);

        var parameterInfos = method.GetParameters();

        var userIdAsInt =  Convert.ChangeType(userId, parameterInfos[0].ParameterType);

        var instance = Activator.CreateInstance(typeController, new[] { httpContext });
        method.Invoke(instance, new [] { userIdAsInt });
    }
}


