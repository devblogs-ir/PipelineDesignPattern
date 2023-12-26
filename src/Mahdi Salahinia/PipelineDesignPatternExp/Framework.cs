using Dumpify;
using System.Reflection;

namespace PipelineDesignPatternExp;

public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (string.IsNullOrWhiteSpace(httpContext.IpAddress))
            throw new CustomException("Ip can't be null");

        "Start authenticate user".Dump();

        var countryIpList = new CountryIp();

        if (countryIpList.IranIps.Contains(httpContext.IpAddress))
        {
            throw new CustomException("Iranian IPs don't have access to the program");
        }

        action(httpContext);

        "End of authenticate user".Dump();
    }

    public void EndPointHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        var urlParts = httpContext.Url.Split('/');

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
    }

    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        "Start ExceptionHandling pipe".Dump();

        try
        {
            action(httpContext);
        }
        catch (CustomException ex)
        {
            Console.WriteLine(ex.Message);
        }

        "End ExceptionHandling pipe".Dump();
    }
}
