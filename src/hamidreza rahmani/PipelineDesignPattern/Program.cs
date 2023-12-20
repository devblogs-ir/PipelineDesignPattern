
using PipelineDesignPattern;


Framework framework = new();

HttpContext iran = new HttpContext { Ip = "192.168.0.130" };
HttpContext america = new HttpContext { Ip = "192.168.0.131" };

CountryController countryController = new();
framework.ExceptionHandling((context) => framework.Authentication(countryController.GetCountryByID, context), iran);
framework.ExceptionHandling((context) => framework.Authentication(countryController.GetCountryByID, context), america);

public class HttpContext
{
    public required string Ip { get; set; }
}