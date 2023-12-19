using PipelineDesignPattern.SimpleImplement.Controllers;
using PipelineDesignPattern.SimpleImplement.Framework;
using PipelineDesignPattern.SimpleImplement.Pipeline;

#region Get_Sample_Input
Console.Write("Please enter your country : ");
string country = Console.ReadLine();
Console.Write("Please enter your ip address : ");
string ipAddress = Console.ReadLine();
#endregion

// set context in pipeline
PipelineContext pipelineContext = new() { RequestIpAddress = ipAddress };

//init new pipline
Pipeline requestPipeline = new(pipelineContext);

// init pipeline steps
var corsStep = new CorsStep();
var exceptionhandlingStep = new ExceptionHandlingStep();
var routeStep = new RouteStep();
var product = new ProductController();
IEndPointPipelineStep<string> authenticationStep = country.ToLower().Equals("iran") ? new IranianAuthenticationStep<string>() : new AmericanAuthenticationStep<string>();

// setup action chaining in pipeline
corsStep.Action = exceptionhandlingStep.Exceute;
exceptionhandlingStep.Action = routeStep.Exceute;
routeStep.Action = authenticationStep.Exceute;
authenticationStep.Func = product.GetAllProducts;

// set start point and excute pipeline
requestPipeline.SetStartProccessPoint(corsStep);
requestPipeline.ExecutePipeline();

Console.ReadKey();