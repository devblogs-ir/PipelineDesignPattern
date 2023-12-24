using Dumpify;
using PipelineDesignPattern;

var countryRepository = new CountryRepository();
var ipService = new IpService(countryRepository);
Pipeline pipeline = new(ipService);
ProductController productController = new();

void ProcessRequest(HttpContext context)
{
    $"Processing Request {context.Id}".Dump();

    pipeline.ExceptionHandller(
        context,
        (context) =>
        {
            pipeline.Routing(
                context,
                (context) =>
                {
                    pipeline.Authorization(context, (context) => ProductController.GetUsers());
                });
        });

    $"End Process of Request {context.Id}".Dump();
}

HttpContext iranRequest = new()
{
    Id = 1,
    IpAdrress = "83.241.2.10"
};

HttpContext usRequest = new()
{
    Id = 2,
    IpAdrress = "64.21.13.94"
};



ProcessRequest(iranRequest);
ProcessRequest(usRequest);