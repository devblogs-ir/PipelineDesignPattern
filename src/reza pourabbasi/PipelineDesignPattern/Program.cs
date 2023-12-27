using PipelineDesignPattern;
using PipelineDesignPattern.Frameworks;

HttpContext httpContext = new() { IP = "85.185.20.177", URL = "" };
HttpContext httpContextUSA = new() { IP = "102.128.167.255", URL = "" };

// ProductsController productsController = new();
// Framework framework = new();

// framework.ExceptionHandling(httpContext,
//     (context) => framework.Authentication(context,
//     (context) => productsController.GetAll(context)));

// framework.ExceptionHandling(httpContextUSA,
//     (context) => framework.Authentication(context,
//     (context) => productsController.GetAll(context)));


Pipeline pipeline = new();

pipeline
.Add(new ExceptionHandling())
.Add(new Authentication())
.Add(new EndPoint());

pipeline.Run(httpContextUSA);