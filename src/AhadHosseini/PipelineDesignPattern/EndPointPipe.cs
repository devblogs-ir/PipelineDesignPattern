using Dumpify;
using System.Reflection;


namespace PipelineDesignPattern;

public class EndPointPipe(Action<HttpContext> next) : Pipe(next)
{

    public override void Handle(HttpContext httpContext)
    {
        "staring End Point ".Dump();
        Uri uri = new Uri(httpContext.Url);
        string UrlNotBaseurl = uri.PathAndQuery; //Not Base Url
        var UrlArray = UrlNotBaseurl.Split("/"); //Array of Url
        string ControllerName = UrlArray[1];
        string ActionName = UrlArray[2];
        var IdValue = UrlArray[3];

        var ControllerFullName = $"{typeof(Framework).Namespace}.{ControllerName}Controller";
        var ControllerType = Type.GetType(ControllerFullName);

        MethodInfo method = ControllerType.GetMethod(ActionName);

        var ParametersInfo = method.GetParameters();
        var UserIdInt = Convert.ChangeType(IdValue, ParametersInfo[0].ParameterType);

        var instans = Activator.CreateInstance(ControllerType, new[] { httpContext });
        method.Invoke(instans, new[] { UserIdInt });

        if (_next != null) _next(httpContext);

        "End End Point".Dump();

    }
}
