using PipelineDesignPattern;
using PipelineDesignPattern.Pipes;
using PipelineDesignPattern.Exceptions;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;

Framework framework = new();
//HttpContext requestGetAllProducts = new() { 
//    IP = "123.185.20.177",
//    Url = "localhost:4545/Orders/GetAll"
//};
HttpContext requestGetUserById = new()
{
    IP = "123.185.20.177",
    Url = "localhost:4545/Products/GetUserById/3"
};

//framework.ExceptionHandling(requestGetAllProducts,
//    (context) => framework.Authentication(context,
//    (context) => framework.EndpointHandling(context,null!)));

//framework.ExceptionHandling(requestGetUserById,
//    (context) => framework.Authentication(context,
//    (context) => framework.EndpointHandling(context,null!)));

//var ep = new EndPointPipe(null!);
//var au = new AuthenticationPipe(ep.Handle);
//var pipeline = new ExceptionHandlingPipe(au.Handle);
var firstHandler = new  Framework.PipelineBuilder().
                        AddPipe<ExceptionHandlingPipe>().
                        AddPipe<AuthenticationPipe>().
                        AddPipe<EndPointPipe>().
                        build();


firstHandler(requestGetUserById);
