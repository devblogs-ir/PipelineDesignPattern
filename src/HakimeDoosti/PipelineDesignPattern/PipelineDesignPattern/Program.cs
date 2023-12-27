// See https://aka.ms/new-console-template for more information


using PipelineDesignPattern;

HttpContext request1 = new()
{
    IP = "102.15.0.0",
    Url = "https://localhost:44387/Product/GetUserBuyId/3"
};

HttpContext request2 = new()
{
    IP = "192.15.0.0",
    Url = "https://localhost:44387/Product/GetUserBuyId/3"
};

 


 

var pipeline = new PipelineBuilder(request1)
   .AddPipe(typeof(ExceptionHandlingPip))
   .AddPipe(typeof(AuthenticationPip))
   .AddPipe(typeof(EndpointPip))
   .Build((ctx) => { });

Console.ReadLine();
 

