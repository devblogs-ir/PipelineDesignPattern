using System.Reflection;
using Dumpify;

public class Framework
{
    public delegate void Action(HttpContext httpContext);
    public void Authentication(HttpContext httpContext,Action function)
    {
        if(httpContext.IP == "10.10.1.1" )
        throw new IpNotValidException("Iran IP is Not Allowed");
        else
        function(httpContext);
        
    }

 public void ExceptionHandeling(HttpContext httpContext,Action<HttpContext> function)
 {
    try
    {
        function(httpContext);
    }
    catch(Exception IpNotValidException)
    {
        "Your IP is not valid".Dump(IpNotValidException.Message);
    }

 }


}