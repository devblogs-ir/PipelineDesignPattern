using PipelineDesignPattern;
using System.Reflection;

Framework framework = new();

HttpContext requestUser1 = new() {
    IP = "123.185.20.177" ,
    Url = "localhost:4545/Products/GetUserById/0"
};

HttpContext requestUser2 = new()
{
    IP = "123.185.20.177",
    Url = "localhost:4545/Products/GetUserById/1"
};
  
var pipeline = new PipelineBuilder()
                        .AddPipe(typeof(ExceptionHandlingPipe))
                        .AddPipe(typeof(AuthenticationPipe))
                        .AddPipe(typeof(EndPointPipe))
                        .Build();

pipeline.Handle(requestUser1);
pipeline.Handle(requestUser2);
pipeline.Handle(requestUser2);
pipeline.Handle(requestUser1);
pipeline.Handle(requestUser2);


public abstract class Pipe(Action<HttpContext> next)
{
    public Action<HttpContext> _next = next;

    public abstract void Handle(HttpContext httpContext);
}

public class ExceptionHandlingPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        try
        {
            Console.WriteLine("Starting ExceptionHandling...");

            if (_next is not null) _next(httpContext);
        }
        catch (IPNotProvideException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class AuthenticationPipe(Action<HttpContext> next) : Pipe(next)
{
    public override void Handle(HttpContext httpContext)
    {
        Console.WriteLine("Starting Authentication...");


        if (httpContext is null)
            throw new IPNotProvideException("ip is not provide");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

        if (_next is not null) _next(httpContext);
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

        var parameterInfos = method.GetParameters();

        var userIdAsInt = Convert.ChangeType(userId, parameterInfos[0].ParameterType);

        var instance = Activator.CreateInstance(typeController, new[] { httpContext });
        method.Invoke(instance, new[] { userIdAsInt });

        if (_next is not null) _next(httpContext);
    }
}


public class PipelineBuilder
{ 
    private List<Type> _pipes = new List<Type>();

    public PipelineBuilder AddPipe(Type pipe)
    {
        _pipes.Add(pipe);
        return this;
    }

 
}