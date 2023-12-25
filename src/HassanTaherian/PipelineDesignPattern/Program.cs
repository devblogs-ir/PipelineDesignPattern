using Dumpify;
using PipelineDesignPattern;
using PipelineDesignPattern.Handlers;

var countryRepository = new CountryRepository();
ProductController productController = new();

void ProcessRequest(HttpContext context)
{
    var ipService = new IpService(countryRepository);

    $"Processing Request {context.Id}".Dump();

    RoutingHandler routingHandler = new();
    ExceptionHandler exceptionHandler = new();
    AuthorizationHandler authorizationHandler = new(ipService);

    PipelineBuilder pipelineBuilder = new();
    pipelineBuilder.AddHandler(exceptionHandler)
                   .AddHandler(authorizationHandler)
                   .AddHandler(routingHandler);

    pipelineBuilder.Run(context);

    $"End Process of Request {context.Id}".Dump();
}

HttpContext iranRequest = new()
{
    Id = 1,
    IpAdrress = "83.241.2.10",
    Request = new HttpRequest { Url = "Product/GetUsers" }
};

HttpContext usRequest = new()
{
    Id = 2,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUsers" }
};

HttpContext getUserByIdRequest = new()
{
    Id = 2,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUserById/2" }
};



ProcessRequest(iranRequest);
ProcessRequest(usRequest);
ProcessRequest(getUserByIdRequest);