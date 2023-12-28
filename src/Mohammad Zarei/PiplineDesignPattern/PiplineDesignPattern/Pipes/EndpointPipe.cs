using System.Reflection;

namespace PiplineDesignPattern.Pipes;
public class EndpointPipe(Action<Context> next) : Pipe(next)
{
    public override void Handle(Context context)
    {
        var segments = context.Url.Split('/');

        var controllerClass = segments[1];
        var actionMethod = segments[2];
        var userIdAsString = segments[3];

        var templateControllerName = $"PiplineDesignPattern.Controllers.{controllerClass}Controller";
        var typeController = Type.GetType(templateControllerName);
        MethodInfo method = typeController!.GetMethod(actionMethod)!;

        var parameterInfos = method!.GetParameters();

        var userIdAsInt = Convert.ChangeType(userIdAsString, parameterInfos[0].ParameterType);

        var instance = Activator.CreateInstance(typeController, new[] { context });

        method.Invoke(instance, new[] { userIdAsInt });

        if (next != null)
            _next.Invoke(context);
    }
}