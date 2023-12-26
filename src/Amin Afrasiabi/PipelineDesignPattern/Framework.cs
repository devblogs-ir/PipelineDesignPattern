using Dumpify;

namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        "Start Authentication...".Dump();
        if (httpContext.Country is CountryIPAddress.Iran)
        {
            throw new IranianIPBlockedException(message: "Iranian IPs are blocked");
        }
        action(httpContext);
    }

    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(httpContext);
            action(httpContext);
            "Done".Dump();
        }
        catch (Exception ex)
        {
            ex.Message.Dump("ERROR!");
        }
    }
}
