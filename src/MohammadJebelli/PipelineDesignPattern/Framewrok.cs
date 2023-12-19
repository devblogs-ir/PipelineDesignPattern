using Dumpify;
using PipelineDesignPattern;

public class Framework
{
    public class Framewrok()
    {
    }
    public delegate void Action(HttpContext context);
    public void ExceptionHandling(HttpContext context, Action function)
    {
        try
        {
            function(context);
        }
        catch (Exception ex)
        {
            "Exception catched: ".Dump(ex.Message);
        }

    }
    public void Authentication(HttpContext context, Action function)
    {
        context.IP.Dump("Start auth...");
        if (context.IP.Contains("Iran"))
        {
            throw new Exception("Sorry you are accessing from Islamic Republic.");
        }
        function(context);
        context.IP.Dump("End auth...");
    }

    public void Cors(HttpContext context, Action function)
    {
        context.IP.Dump("Start Cors...");
        function(context);
        context.IP.Dump("End Cors...");

    }
}