using System.Reflection;

namespace PipelineDesignPattern.Handlers;
public class EndPointHandler : BaseHandler
{
    public override void Handle(HttpContext context)
    {
        var endPoint = context.Request.EndPoint;

        if (endPoint is null)
        {
            return;
        }

        var type = Assembly.GetExecutingAssembly().GetType($"PipelineDesignPattern.{endPoint.ControllerName}Controller");

        if (type is null)
        {
            throw new EndPointNotFoundException(context.Request.Url);
        }

        var methodInfo = type.GetMethod(endPoint.ActionName) ?? throw new EndPointNotFoundException(context.Request.Url);

        if (methodInfo is null)
        {
            throw new EndPointNotFoundException(context.Request.Url);
        }

        var classInstance = Activator.CreateInstance(type);

        methodInfo.Invoke(classInstance, [endPoint.Parameter]);
    }
}
