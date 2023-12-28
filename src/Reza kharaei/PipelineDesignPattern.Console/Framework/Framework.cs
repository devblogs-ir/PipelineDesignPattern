
namespace PipelineDesignPattern.Framework;

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
        var SplitedUrl = httpContext.Url.Split('/');
        var controllerName = SplitedUrl[SplitedUrl.Length - 2];
        var actionName = SplitedUrl[SplitedUrl.Length - 1];
        
        var projectNamespace = typeof(Program).Namespace;
        var controllerAssemblyName = $"{projectNamespace}.Controllers.{controllerName}Controller";
        var controllerType = Type.GetType(controllerAssemblyName);
        //var controllerInstanse = Activator.CreateInstance(type: controllerType, args: new[] { httpContext });
        
        if (controllerType is null)
            throw new Exception($"ٖthere is no controller named {controllerName}");

        var method = controllerType.GetMethod(actionName);
        if (method is null)
            throw new Exception($"ٖthere is no method named {actionName} in {controllerName}");
    
        method.Invoke(httpContext, null);
    }
}