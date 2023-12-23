namespace PipelineDesignPattern;

using Dumpify;

public class Framework
{
    private readonly IIpService ipService;
    public Framework(IIpService ipService)
    {
        this.ipService = ipService;
    }
    public void Auth(HttpContext context, Action<HttpContext> action)
    {
        "Start Auth".Dump();

        if (ipService.IsOriginFromBannedCountries(context.IpNumber))
        {
            var originCountry = ipService.GetOriginCountry(context.IpNumber);
            throw new Exception($"Your from {originCountry?.Name}:(");
        }

        action(context);
    }
    public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
    {
        try
        {
            action(context);
        }
        catch (Exception ex)
        {
            ex.Dump();
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
