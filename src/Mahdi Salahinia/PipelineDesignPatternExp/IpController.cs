using Dumpify;

namespace PipelineDesignPatternExp;

public class IpController
{
    public void GetUserIp(HttpContext httpContext)
    {
        $"User Ip: {httpContext.IpAddress}".Dump();
    }
}
