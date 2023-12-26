using System.Reflection;

namespace PipeLineDesignPattern;

public class Framework
{
    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            action(httpContext);
        }
        catch (NotProvidedIpException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception ex) when (ex is InvalidException)
        {
            Console.WriteLine(ex.Message);
        } 
    }


    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (httpContext is null)
            throw new NotProvidedIpException(httpContext.Ip);
        else if (httpContext.Ip is "87.198.10.300")
            throw new InvalidException();

        action(httpContext);
    }

    public void EndPointHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        var UrlWithoutQueries = httpContext.Url.Split("?")[0];
        var UrlParts = UrlWithoutQueries.Split("/");
        var controller = UrlParts[0];
        var actionName = UrlParts[1];

        var Controller = $"PipeLineDesignPattern.{controller}Controller";
        var type = Type.GetType(controller);
        MethodInfo method = type.GetMethod(actionName);
        
        var instance = Activator.CreateInstance(type);

        method.Invoke(instance, null);
        
        
    }
}
