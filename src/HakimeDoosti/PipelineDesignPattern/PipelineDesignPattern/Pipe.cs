using Dumpify;
using PipelineDesignPattern;
using System.Reflection;

namespace PipelineDesignPattern
{
    public abstract class Pipe(Action<HttpContext> next)
    {
        public Action<HttpContext> _next = next;

        public abstract void Handel(HttpContext httpContent);
         
    }
}
public class AuthenticationPip(Action<HttpContext> next) : Pipe(next)
{
    public override void Handel(HttpContext httpContent)
    {
        "begin AuthenticationPip".Dump();

        if (httpContent is null) 
            throw new CustomException("context is null ");

        if (httpContent.IP is null) 
            throw new CustomException("IP is null ");

        if (httpContent.IP == "192.15.0.0") 
            throw new CustomException("you are from Iran");

        if (_next is not null) _next(httpContent);
    }
}
public class ExceptionHandlingPip(Action<HttpContext> next) : Pipe(next)
{
    public override void Handel(HttpContext httpContent)
    {
        "begin ExceptionHandlingPip".Dump();
        try
        {
            if (_next is not null) _next(httpContent);
        }
        catch (CustomException ex)
        {
            ex.Message.Dump();
        }
        
    }
}
public class EndpointPip(Action<HttpContext> next) : Pipe(next)
{
    public override void Handel(HttpContext httpContent)
    {
        "begin EndpointPip".Dump();
        var urlParts = httpContent.Url.Split('/');
        var methodName = "";
        var controllerName = "";
        var UserId = "";
        try
        {
            UserId = urlParts[5];
            methodName = urlParts[4];
            controllerName = urlParts[3];
        }
        catch
        {
            throw new CustomException(" Url Not Valid ");
        }

        var templateControllerName = $"PipelineDesignPattern.{controllerName}Controller";

        var typeController = Type
            .GetType(templateControllerName) ??
            throw new CustomException(" type Not Found ");

        var instanceController = Activator
            .CreateInstance(typeController, new[] { httpContent }) ??
            throw new CustomException(" Controller Not Found ");

        MethodInfo method = typeController
            .GetMethod(methodName) ??
            throw new CustomException(" method Not Found ");

        var parameters = method.GetParameters();

        var userIdAsInt = Convert
            .ChangeType(UserId,
            parameters[0].ParameterType);

        method.Invoke(instanceController, new[] { userIdAsInt });

        if (_next is not null) _next(httpContent);
    }
}