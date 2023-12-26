using PipelineDesignPattern.SimpleImplement.Common;
using PipelineDesignPattern.SimpleImplement.CustomExceptions;
using PipelineDesignPattern.SimpleImplement.Pipeline;
using System.Reflection;

namespace PipelineDesignPattern.SimpleImplement.Framework;
public class EndPointStep : IPipe
{
    public Action<IPipelineContext> Next { get; set; }

    public void Invoke(IPipelineContext context)
    {
        var controller = Url.GetController(context.Url);
        var method = Url.GetAction(context.Url);

        var metaData = $"PipelineDesignPattern.SimpleImplement.Controllers.{controller}Controller";
        string assemblyPath = Assembly.GetExecutingAssembly().Location;

        Type type = Assembly.LoadFrom(assemblyPath).GetType(metaData);

        if (!type.IsInstancable())
            throw new InvalidRequestException("url is not valid");

        var controllerInstance = Activator.CreateInstance(type);
       
        MethodInfo action = type.GetMethod(method);
        if (action is not null)
            action.Invoke(controllerInstance, new object[] { });
        else
            throw new InvalidDataException();
       
    }
}
