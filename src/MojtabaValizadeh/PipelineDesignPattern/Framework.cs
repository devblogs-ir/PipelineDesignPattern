using Dumpify;

namespace PipelineDesignPattern;

public class Framework
{
    public void Authentication(Action<HttpContext> func,HttpContext httpContent)
    {
        if(httpContent.Ip is "192.168.0.130")
        {
            throw new CountryBlockedExceptionHandler("you are from iran");
        }
        func(httpContent);
    }

    public void ExceptionHandling(Action<HttpContext> func, HttpContext httpContent)
    {
        try
        {
            func(httpContent);
        }
        catch (CountryBlockedExceptionHandler e)
        {
            "catched".Dump(e.Message);
        }
    }
}