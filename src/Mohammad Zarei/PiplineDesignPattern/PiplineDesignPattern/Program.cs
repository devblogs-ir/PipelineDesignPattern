using PiplineDesignPattern;
using PiplineDesignPattern.Pipes;

var getUserRequest1 = new Context 
{ 
    UserIp = "America Ip",
    Url = "localhost:7432/Users/Get/1"
};

var getUserRequest2 = new Context
{
    UserIp = "America Ip",
    Url = "localhost:7432/Users/Get/2"
};


var builder = new PipelineBuilder()
    .WithType(typeof(ExceptionHandlingPipe))
    .WithType(typeof(AuthenticationHandlingPipe))
    .WithType(typeof(EndpointPipe))
    .Build();

builder.Invoke(getUserRequest1);
Console.WriteLine("================================");
builder.Invoke(getUserRequest2);
