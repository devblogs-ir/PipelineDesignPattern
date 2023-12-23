using Dumpify;
using PipelineDesignPattern;

var countryRepository = new CountryRepository();
var ipService = new IpService(countryRepository);
Framework framework = new(ipService);
ProductController productController = new();

void ProcessRequest(HttpContext context)
{
    $"Processing Request {context.Id}".Dump();

    framework.ExceptionHandller(
        context,
        (context) =>
        {
            framework.Routing(
                context,
                (context) =>
                {
                    framework.Authorization(context, (context) => ProductController.GetUsers());
                });
        });

    $"End Process of Request {context.Id}".Dump();
}

HttpContext iranRequest = new()
{
    Id = 1,
    IpNumber = "83.241.2.10"
};

HttpContext usRequest = new()
{
    Id = 2,
    IpNumber = "64.21.13.94"
};



ProcessRequest(iranRequest);
ProcessRequest(usRequest);