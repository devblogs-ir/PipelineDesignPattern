using Dumpify;

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
        catch (CustomException ex)
        {
            throw new CustomException("Authentication was unsuccessful");
        }

        "End ExceptionHandling pipe".Dump();
    }
}
