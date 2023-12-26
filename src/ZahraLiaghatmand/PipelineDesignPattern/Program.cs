using PipelineDesignPattern;
using System.Reflection;

Framework framework = new();
//HttpContext requestGetAllProducts = new() { 
//    IP = "123.185.20.177",
//    Url = "localhost:4545/Orders/GetAll"
//};
HttpContext requestGetUserById = new()
{
    IP = "123.185.20.177",
    Url = "localhost:4545/Products/GetUserById/3"
};

//framework.ExceptionHandling(requestGetAllProducts,
//    (context) => framework.Authentication(context,
//    (context) => framework.EndpointHandling(context,null!)));

//framework.ExceptionHandling(requestGetUserById,
//    (context) => framework.Authentication(context,
//    (context) => framework.EndpointHandling(context,null!)));

var ep = new EndPointPipe(null!);
var au = new AuthenticationPipe(ep.Handle);
var eh = new ExceptionHandlingPipe(au.Handle);
eh.Handle(requestGetUserById);

public abstract class Pipe(Action<HttpContext> next)
{
    public Action<HttpContext> _next = next;

    public abstract void Handle(HttpContext httpContext);
}
public class AuthenticationPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        Console.WriteLine("starting Auth...");
        if (httpContext is null)
            throw new IPNotProvideException("IP is not provided");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

        if (_next != null)
            _next(httpContext);
    }
}
public class ExceptionHandlingPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        Console.WriteLine("starting except...");
        try
        {
            if (_next != null)
                _next(httpContext);
        }
        catch (Exception ex) when (ex is IPNotProvideException)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is InvalidIPException)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
public class EndPointPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        var parts = httpContext.Url.Split('/');
        var controllerClass = parts[1];
        var actionMethod = parts[2];
        var userId = parts[3];
        var templateControllerName = $"PipelineDesignPattern.{controllerClass}Controller";
        var typeController = Type.GetType(templateControllerName);
        MethodInfo method = typeController.GetMethod(actionMethod);
        var parametersInfo = method.GetParameters();

        var userIdAsInt = Convert.ChangeType(userId, parametersInfo[0].ParameterType);


        var instance = Activator.CreateInstance(typeController, new[] { httpContext });
        //var productsController = instance as ProductsController;

        method.Invoke(instance, new[] { userIdAsInt });

        if (_next != null)
            _next(httpContext);
    }
}