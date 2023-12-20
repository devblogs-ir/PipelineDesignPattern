using Dumpify;

namespace PipeLineApp;

public class FilteringController
{
    public void GetIp(HttpContext httpContext)
    {
        $"ip address is {httpContext.Ip}".Dump("FilteringController.GetIp");
    }
}