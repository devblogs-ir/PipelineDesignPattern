using Dumpify;
using Newtonsoft.Json;
using PipelineDesignPattern.Common;
using System.Reflection;

namespace PipelineDesignPattern.Pipes;

public class RequestMappingMiddleware(Action<Context> next) : Middleware(next)
{
    public override void Handle(Context context)
    {
        "start mapping".Dump();
        var route = context.Route.SplitRoute();
        string assemblyPath = $"PipelineDesignPattern.Controllers.{route.Controller}Controller";

        Type type = Type.GetType(assemblyPath)!;

        var instance = Activator.CreateInstance(type);

        MethodInfo methodInfo = type.GetMethod(route.Method)!;
        var methodParameters = methodInfo.GetParameters();

        object response = new();
        if (methodParameters.Length > 0)
            response = methodInfo.InvokeWithParameters(instance!, route.Query);
        else
            response = methodInfo.Invoke(instance, null)!;

        Console.WriteLine(JsonConvert.SerializeObject(response));

        if (_next != null)
            _next.Invoke(context);
        "end mapping".Dump();
    }
}
