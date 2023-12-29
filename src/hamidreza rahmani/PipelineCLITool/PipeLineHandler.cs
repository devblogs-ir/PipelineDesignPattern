using System.Reflection;
namespace PipelineDesignPattern;


public abstract class Pipe
{ 
    public abstract void Handle(HttpContext httpContext);
}

public class ExceptionHandlingPipe : Pipe
{
    public override void Handle(HttpContext httpContext)
    {
        try
        {
            Console.WriteLine("Starting ExceptionHandling...");

        }
        catch (IPNotProvideException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class AuthenticationPipe : Pipe
{

    
    public override void Handle(HttpContext httpContext)
    {
        Console.WriteLine("Starting Authentication...");
        
        if (httpContext is null)
            throw new IPNotProvideException("ip is not provide");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

    }
}


public class EndPointPipe : Pipe
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

    
    public PipelineBuilder Build()
    {
        var handler = new PipelineBuilder();

        foreach (var pipe in _pipes)
        {
            handler.AddPipe(pipe);
        }

        return handler;
    }
    public void Handle(HttpContext requestUser1)
    {   
        foreach (var pipeType in _pipes)
        {
            // Create an instance of the pipe
            var pipe = Activator.CreateInstance(pipeType);
            // Invoke the Handle method 
            pipeType.GetMethod("Handle").Invoke(pipe,new[] { requestUser1 });
        }
        
     
    }
 
}