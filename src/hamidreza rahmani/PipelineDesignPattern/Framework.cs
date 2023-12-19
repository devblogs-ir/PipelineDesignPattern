using Dumpify;
using System;

namespace PipelineDesignPattern;

public class Framework
{
    public void Authentication(Action<HttpContext> func, HttpContext httpContent)
    {
        if (httpContent.Ip is "192.168.0.130")
        {
            throw new CountryBlockedException("you are from iran");
        }
        func(httpContent);
    }

    public void ExceptionHandling(Action<HttpContext> func, HttpContext httpContent)
    {
        try
        {
            func(httpContent);
        }
        catch (CountryBlockedException e)
        {
            "catched".Dump(e.Message);
        }
    }
}