using PipelineDesignPattern.SimpleImplement.Controllers;
using PipelineDesignPattern.SimpleImplement.Framework;
using PipelineDesignPattern.SimpleImplement.Pipeline;

#region Get_Sample_Input
Console.Write("Please enter your country (please choose Iran or Usa): ");
string country = Console.ReadLine();
Console.Write("Please enter your ip address : ");
string ipAddress = Console.ReadLine();
Console.Write("Please enter your endpoint : ");
string endpoint = Console.ReadLine();
#endregion

// set context in pipeline
PipelineContext pipelineContext = new() { RequestIpAddress = ipAddress, Country = country,Url=endpoint };

// init pipes
var corsStep = new CorsStep();
var exceptionhandlingStep = new ExceptionHandlingStep();
var routeStep = new RouteStep();
var product = new ProductController();
var authenticationStep = new AuthenticationStep();

// setup action chaining in pipeline
corsStep.Next = exceptionhandlingStep.Invoke;
exceptionhandlingStep.Next = routeStep.Invoke;
routeStep.Next = authenticationStep.Invoke;
authenticationStep.Next = new EndPointStep().Invoke;

// set pipes and run 
 new Pipeline(pipelineContext)
               .AddPipe(corsStep)
               .AddPipe(exceptionhandlingStep)
               .AddPipe(routeStep)
               .AddPipe(authenticationStep)
               .Run();

Console.ReadKey();