using System.Reflection;
using Dumpify;

namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext context, Action<HttpContext> next)
    {
        "Start authenticate user".Dump();

        if (IpRangeChecker.IpRangeCheck(context.IP))
            throw new IpNotAllowedException(ip: context.IP);
        else
            next(context);

        "End of authenticate user".Dump();
    }

    public void ExceptionHandling(HttpContext context, Action<HttpContext> next)
    {
        "Start ExceptionHandling pipe".Dump();
        try
        {
            next(context);
        }
        catch (IpNotAllowedException e)
        {
            e.Message.Dump();
        }
        catch (Exception e)
        {
            e.Message.Dump();
        }

        "End ExceptionHandling pipe".Dump();
    }

    public void EndPointHandling(HttpContext context, Action<HttpContext> next)
    {
        "Start EndPointHandling pipe".Dump();

        var urlPart = context.Url.Split("/");
        var controllerClass = urlPart[1];
        var actionMethod = urlPart[2];

       var controllerTemplate = $"PipelineDesignPattern.{controllerClass}Controller";

        if (Type.GetType(controllerTemplate) is Type controllerType)
        {
            var controller = Activator.CreateInstance(controllerType , new []{context}) ;

            if (controllerType.GetMethod(actionMethod) is MethodInfo action)
            {
                action.Invoke(controller, null);

            }

        }

        "End EndPointHandling pipe".Dump();


    }

}

