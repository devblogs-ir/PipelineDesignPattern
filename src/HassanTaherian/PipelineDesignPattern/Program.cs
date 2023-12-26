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
    EndPointHandler endPointHandler = new();


    PipelineBuilder pipelineBuilder = new();
    pipelineBuilder.AddHandler(exceptionHandler)
                   .AddHandler(authorizationHandler)
                   .AddHandler(routingHandler)
                   .AddHandler(endPointHandler);

    pipelineBuilder.Run(context);

    $"End Process of Request {context.Id}".Dump();
    Console.WriteLine("\n");
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
    Id = 3,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUserById/2" }
};

HttpContext invalidUrlRequestFormat = new()
{
    Id = 4,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUser/name/2" }
};


HttpContext invalidEndPointRequest = new()
{
    Id = 5,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUserByName/2" }
};



ProcessRequest(iranRequest);
ProcessRequest(usRequest);
ProcessRequest(getUserByIdRequest);
ProcessRequest(invalidUrlRequestFormat);
ProcessRequest(invalidEndPointRequest);