using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp;

public abstract class Pipe(Action<HttpContext> next)
{
    public Action<HttpContext> _next = next;

    public abstract void Handle(HttpContext context);
}

public class Authentication(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext context)
    {
        if (string.IsNullOrWhiteSpace(context.IpAddress))
            throw new CustomException("Ip can't be null");

        "Start authenticate user".Dump();

        var countryIpList = new CountryIp();

        if (countryIpList.IranIps.Contains(context.IpAddress))
        {
            throw new CustomException("Iranian IPs don't have access to the program");
        }

        if (_next is not null) _next(context);

        "End of authenticate user".Dump();
    }
}

public class ExceptionHandling(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext context)
    {
        try
        {
            "Start ExceptionHandling pipe".Dump();
            if (_next is not null) _next(context);
        }
        catch (CustomException ex)
        {
            Console.WriteLine(ex.Message);
        }

        "End ExceptionHandling pipe".Dump();
    }
}

public class EndPointHandling(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext context)
    {
        var urlParts = context.Url.Split('/');

        var controllerName = urlParts[1];
        var methodName = urlParts[2];
        var option = urlParts[3];

        var assemblyAddress = $"PipelineDesignPatternExp.{controllerName}Controller";

        var type = Type.GetType(assemblyAddress);

        MethodInfo method = type.GetMethod(methodName);

        var parametersInfo = method.GetParameters();

        var optionAsInt = Convert.ChangeType(option, parametersInfo[0].ParameterType);

        var runTimeInstance = Activator.CreateInstance(type);

        //var productsController = runTimeInstance as ProductsController;

        method.Invoke(runTimeInstance, new[] { optionAsInt });

        if (_next is not null) _next(context);
    }
}
