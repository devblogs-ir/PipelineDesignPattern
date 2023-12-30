using Dumpify;

namespace PipelineDesignPattern;
public class AuthorizationHandler : BaseHandler
{
    private readonly IIpService ipService;
    public AuthorizationHandler(IIpService ipService)
    {
        this.ipService = ipService;
    }
    public override void Handle(HttpContext context)
    {
        "Start Auth".Dump();

        if (ipService.IsOriginFromBannedCountries(context.IpAdrress))
        {
            var originCountry = ipService.GetOriginCountry(context.IpAdrress);
            throw new AccessingFromBannedCountryException(originCountry?.Name);
        }

        next?.Invoke(context);
    }
}
