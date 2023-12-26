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
var cors = new CorsStep();
var exceptionhandling = new ExceptionHandlingStep();
var route = new RouteStep();
var product = new ProductController();
var authentication = new AuthenticationStep();

// setup action chaining in pipeline
cors.Next = exceptionhandling.Invoke;
exceptionhandling.Next = route.Invoke;
route.Next = authentication.Invoke;
authentication.Next = new EndPointStep().Invoke;

// set pipes and run 
 new Pipeline(pipelineContext)
               .AddPipe(cors)
               .AddPipe(exceptionhandling)
               .AddPipe(route)
               .AddPipe(authentication)
               .Run();

Console.ReadKey();