using Dumpify;

namespace PipelineDesignPattern;

public class Framework
{
    public delegate void Actions<T>(HttpContext httpContext);
    public void Authentication(Actions<HttpContext> func,HttpContext httpContent)
    {
        if(httpContent.Ip=="192.168.0.130")
        {
            throw new Exception("you are from iran");
        }
        func(httpContent);
    }

    public void ExceptionHandling(Actions<HttpContext> func, HttpContext httpContent)
    {
        try
        {
            func(httpContent);
        }
        catch (Exception e)
        {
            "catched".Dump(e.Message);
        }
    }
}