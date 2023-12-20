using Dumpify;

namespace PipelineDesignPattern;
public class Framework
{
    public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    {
		"Start Authentication...".Dump();
		if (httpContext.Country is CountryIPPAddress.Iran)
		{
			throw new Exception(message: "Iranian IPs are blocked");
		}
		action(httpContext);
    }

    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    {
		try
		{
			action(httpContext);
			"Done".Dump();
		}
		catch (Exception ex)
		{
			ex.Message.Dump();
		}
    }
}
