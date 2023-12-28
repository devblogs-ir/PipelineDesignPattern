
using System.Reflection;
using PipelineDesignPatternConsole.Models;

namespace PipelineDesignPatternConsole.Framework;

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
        try
        {
            Console.WriteLine($"Starting Authentication...  ({httpContext.IP})");

            var filtering = new Filtering();
            if (filtering.IsValid(httpContext.IP) == false)
                throw new Exception("You are from Iran!");

            action(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

            Console.WriteLine($"Finish Authentication.  ({httpContext.IP})");
        }
    }

    public void EndPointHanling(HttpContext httpContext, Action<HttpContext> action)
    {
        var request = UrlHelper.ParseUrl(httpContext.Url);
        
        var projectNamespace = Assembly.GetExecutingAssembly().GetName().Name;
        Console.WriteLine(projectNamespace);
        var controllerAssemblyName = $"{projectNamespace}.Controllers.{request.controllerName}Controller";
        
        var controllerType = Type.GetType(controllerAssemblyName);
        if (controllerType is null)
            throw new Exception($"there is no controller named '{request.controllerName}'.");
  
        var method = controllerType.GetMethod(request.actionName); 
        if (method is null)
            throw new Exception($"there is no action named '{request.actionName}' in '{request.controllerName}' controller.");
   
        var controllerInstanse = Activator.CreateInstance(type: controllerType);

        if (request.parameterId.HasValue)
        {
            var parameterInfo = method.GetParameters();
            var intId = Convert.ChangeType(request.parameterId, parameterInfo[0].ParameterType);
            method.Invoke(controllerInstanse, new [] { intId });
        }
        else
            method.Invoke(controllerInstanse, null);
    }
}