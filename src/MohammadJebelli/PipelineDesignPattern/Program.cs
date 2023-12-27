using Dumpify;
using PipelineDesignPattern;




//var httpContext1 = new HttpContext(IP:"185.188.104.10", Url:"Product/GetAll");
var httpContext2 = new HttpContext(IP: "216.239.38.120", Url: "localhost:4040/Product/GetAll");

//ProductController controller = new ProductController(httpContext1);

//"US IP----------------------------".Dump();
//framework.ExceptionHandling(
//    httpContext2, (context) =>
//        framework.Authentication(context, controller.GetAllUser)
//        );

//"Iran IP----------------------------".Dump();
//framework.ExceptionHandling(
//    httpContext1, (context) =>
//        framework.Authentication(context, controller.GetAllUser)
//        );



 new PipeBuilder()
    .AddPipe(typeof(ExceptionHandlerPipe))
    .AddPipe(typeof(AuthenticaionPipe))
    .AddPipe(typeof(EndPointPipe))
    .Build(httpContext2);
