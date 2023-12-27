//The code demonstrates how the Pipeline Design Pattern can be used to handle a chain of pipes in different contexts. 

using PipelineDesignPattern.Builders;
using PipelineDesignPattern.Pipelines;

HttpContext request1 = new()
{
    IP = "164.215.56.0",
    Url = "localhost:4545/Product/GetAllProduct/1"
};

HttpContext request2 = new()
{
    IP = "123.215.56.0",
    Url = "localhost:4545/Product/GetAllProduct/2"
};

new PipelineBuilder([request1, request2])
    .AddPipe(typeof(EndPointPipe))
    .AddPipe(typeof(AuthenticationPipe))
    .AddPipe(typeof(ExceptionHandlingPipe))
    .Build();