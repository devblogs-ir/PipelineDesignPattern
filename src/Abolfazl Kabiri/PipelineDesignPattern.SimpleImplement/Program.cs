using PipelineDesignPattern.SimpleImplement.Controllers;
using PipelineDesignPattern.SimpleImplement.Framework;
using PipelineDesignPattern.SimpleImplement.Pipeline;

Console.Write("Please enter your country : ");
string country = Console.ReadLine();

Console.Write("Please enter your ip address : ");
string ipAddress = Console.ReadLine();

PipelineContext pipelineContext = new() { RequestIpAddress = ipAddress };

Pipeline requestPipeline = new(pipelineContext);

IEndPoindPipelineStep<string> authenticationStep = null;

var corsStep = new CorsStep();
var exceptionhandlingStep = new ExceptionHandlingStep();
var routeStep = new RouteStep();

if (country.ToLower().Equals("iran"))
{
    authenticationStep = new IranianAuthenticationStep<string>();
}
else
{
    authenticationStep = new AmericanAuthenticationStep<string>();
}
var americanAuthenticationStep = new AmericanAuthenticationStep<string>();
var product = new ProductController();

corsStep.Action = exceptionhandlingStep.Exceute;
exceptionhandlingStep.Action = routeStep.Exceute;
routeStep.Action = authenticationStep.Exceute;

authenticationStep.Func = product.GetAllProducts;

requestPipeline.SetStartProccessPoint(corsStep);


requestPipeline.ExecutePipeline();

Console.ReadKey();