namespace PipelineDesignPattern;

using Dumpify;

public class Pipeline
{
    private readonly IIpService ipService;
    public Pipeline(IIpService ipService)
    {
        this.ipService = ipService;
    }
    public void Authorization(HttpContext context, Action<HttpContext> action)
    {
        "Start Auth".Dump();

        if (ipService.IsOriginFromBannedCountries(context.IpAdrress))
        {
            var originCountry = ipService.GetOriginCountry(context.IpAdrress);
            throw new AccessingFromBannedCountryException(originCountry?.Name);
        }

        action(context);
    }
    public void ExceptionHandller(HttpContext context, Action<HttpContext> action)
    {
        try
        {
            action(context);
        }
        catch (AccessingFromBannedCountryException ex)
        {
            ex.Message.Dump("!!!Error!!!");
        }
        finally
        {
            "End Exception Handling".Dump();
        }
    }

    public void Routing(HttpContext context, Action<HttpContext> action)
    {
        "Start Routing".Dump();
        action(context);
    }

}
