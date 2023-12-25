using Dumpify;
using PipelineDesignPattern;
using PipelineDesignPattern.Handlers;

var countryRepository = new CountryRepository();
//Pipeline pipeline = new(ipService);
ProductController productController = new();

void ProcessRequest(HttpContext context)
{
    var ipService = new IpService(countryRepository);

    $"Processing Request {context.Id}".Dump();

    RoutingHandler routingHandler = new();
    ExceptionHandler exceptionHandler = new();
    AuthorizationHandler authorizationHandler = new(ipService);

    exceptionHandler.Next = authorizationHandler.Handle;
    authorizationHandler.Next = routingHandler.Handle;
    routingHandler.Next = productController.GetUsers;

    exceptionHandler.Handle(context);

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