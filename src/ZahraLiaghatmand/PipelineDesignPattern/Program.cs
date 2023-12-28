using PipelineDesignPattern;
using PipelineDesignPattern.Pipes;
using PipelineDesignPattern.Exceptions;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;

Framework framework = new();

HttpContext requestGetUserById = new()
{
    IP = "123.185.20.177",
    Url = "localhost:4545/Products/GetUserById/3"
};

var firstHandler = new  Framework.PipelineBuilder().
                        AddPipe<ExceptionHandlingPipe>().
                        AddPipe<AuthenticationPipe>().
                        AddPipe<EndPointPipe>().
                        build();


firstHandler(requestGetUserById);
