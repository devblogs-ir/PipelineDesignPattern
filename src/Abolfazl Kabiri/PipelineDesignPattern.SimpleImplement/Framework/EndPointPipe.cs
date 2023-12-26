using PipelineDesignPattern.SimpleImplement.Common;
using PipelineDesignPattern.SimpleImplement.CustomExceptions;
using PipelineDesignPattern.SimpleImplement.Pipeline;
using System.Reflection;

namespace PipelineDesignPattern.SimpleImplement.Framework;
public class EndPointPipe : IPipe
{
    public Action<IPipelineContext> Next { get; set; }

    public void Invoke(IPipelineContext context)
    {
        (string controller, string method) = Url.GetUrlPath(context.Url);

        var metaData = $"PipelineDesignPattern.SimpleImplement.Controllers.{controller}Controller";
        string assemblyPath = Assembly.GetExecutingAssembly().Location;
        Type type = Assembly.LoadFrom(assemblyPath).GetType(metaData);

        if (!type.IsInstancable())
            throw new InvalidRequestException(context.Url);

        var controllerInstance = Activator.CreateInstance(type);

        MethodInfo action = type.GetMethod(method);

        if (action is null)
            throw new InvalidRequestException(context.Url);

        action.Invoke(controllerInstance, new object[] { });
    }
}
