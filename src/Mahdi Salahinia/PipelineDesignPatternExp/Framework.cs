using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PipelineDesignPatternExp;

public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        if (string.IsNullOrWhiteSpace(httpContext.IpAddress))
            throw new CustomException("Ip can't be null");

        "Start authenticate user".Dump();

        var countryIpList = new CountryIp();

        if (countryIpList.IranIps.Contains(httpContext.IpAddress))
        {
            throw new CustomException("Iranian IPs don't have access to the program");
        }
        else
            action(httpContext);

        "End of authenticate user".Dump();
    }

    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        "Start ExceptionHandling pipe".Dump();

        try
        {
            action(httpContext);
        }
        catch
        {
            throw new CustomException("Authentication was unsuccessful");
        }

        "End ExceptionHandling pipe".Dump();
    }
}
