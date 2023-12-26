using PipelineDesignPattern.SimpleImplement.CustomExceptions;
using PipelineDesignPattern.SimpleImplement.Pipeline;
using System.Net;

namespace PipelineDesignPattern.SimpleImplement;
public static class Ip
{
    private static IEnumerable<IpCountryRange> GetIpCountryRanges()
    {
        return new List<IpCountryRange>()
        {
            new IpCountryRange{ CountryName = "Iran",Range = "194"},
            new IpCountryRange{ CountryName = "Usa",Range = "200"}
        };
    }
    public static bool IsValidate(IPipelineContext context)
    {
        IPAddress parsedIpAddress;
        IPAddress.TryParse(context.RequestIpAddress, out parsedIpAddress);
        if (!parsedIpAddress.ToString().Equals(context.RequestIpAddress))
            throw new InvalidIpAddressException(context.RequestIpAddress);
        else
        {
            var validRange = GetIpCountryRanges().SingleOrDefault(i => i.Range.Equals(context.RequestIpAddress.Split('.')[0]));
            if (validRange is null)
                throw new UnknownIpAddressException(context.RequestIpAddress);
            if (!context.Country.ToLower().Equals(validRange.CountryName.ToLower()))
                throw new InaccessibilityException(validRange.CountryName);
            return true;
        }
    }
}
public class IpCountryRange
{
    public string CountryName { get; set; }
    public string Range { get; set; }
}
