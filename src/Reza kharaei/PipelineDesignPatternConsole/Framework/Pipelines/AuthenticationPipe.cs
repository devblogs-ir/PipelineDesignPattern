using PipelineDesignPatternConsole.Framework.Helpers;
using PipelineDesignPatternConsole.Models;

namespace PipelineDesignPatternConsole.Framework.Pipelines;

public class AuthenticationPipe : Pipe
{ 
    public AuthenticationPipe(Action<HttpContext> next): base(next)
    {
        
    }

    public AuthenticationPipe() : base(null)
    {
        
    }

    public override void Handler(HttpContext httpContext)
    {
        try
        {
            Console.WriteLine($"Starting Authentication...  ({httpContext.IP})");

            var filtering = new FilteringHelper();
            if (filtering.IsValid(httpContext.IP) == false)
                throw new Exception("You are from Iran!");

             if (_next is not null) 
                _next(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

            Console.WriteLine($"Finish Authentication.  ({httpContext.IP})");
        }
    }
}