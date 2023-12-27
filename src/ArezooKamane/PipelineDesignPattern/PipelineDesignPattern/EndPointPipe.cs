using System.Reflection;
using Dumpify;

namespace PipelineDesignPattern;

public class EndPointPipe : BasePipe
{
    public EndPointPipe(Action<HttpContext> next) : base(next) { }

    public override void Invoke(HttpContext context)
    {
        "Start EndPointHandling pipe".Dump();

        var urlPart = context.Url.Split("/");
        var controllerClass = urlPart[1];
        var actionMethod = urlPart[2];

        var controllerTemplate = $"PipelineDesignPattern.{controllerClass}Controller";

        if (Type.GetType(controllerTemplate) is Type controllerType)
        {
            var controller = Activator.CreateInstance(controllerType, new[] { context });

            if (controllerType.GetMethod(actionMethod) is MethodInfo action)
            {
                action.Invoke(controller, null);

            }

        }

        "End EndPointHandling pipe".Dump();
    }
}

