using Dumpify;

namespace PipelineDesignPattern;

public class CountryController
{
    public void GetCountryByID(HttpContext httpContext)
    {
        $"your ip is {httpContext.Ip}".Dump("request GetCountryByID");
    }
}