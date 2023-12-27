using Dumpify;
using System.Reflection;

namespace PipelineDesignPattern.Pipelines;

public class EndPointPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        "Start Routing...".Dump("Routing");

        var parts = httpContext.Url.Split('/');

        var controllerClass = parts[1];

        var actionMethod = parts[2];

        var userId = parts[3];

        var templateControllerName = $"PipelineDesignPattern.{controllerClass}Controller";

        var typeController = Type.GetType(templateControllerName);

        MethodInfo method = typeController.GetMethod(actionMethod);

        var parameterInfos = method.GetParameters();

        var userIdAsInt = Convert.ChangeType(userId, parameterInfos[0].ParameterType);

        //create an instance in runtime dynamically
        var instance = Activator.CreateInstance(typeController, new[] { httpContext });

        method.Invoke(instance, new[] { userIdAsInt });

        if (_next is not null) _next(httpContext);

    }
}