using Dumpify;
using PipelineDesignPattern;



//Iran IP
var httpContext1 = new HttpContext(IP:"185.188.104.10", Url:"localhost:4040/Product/GetAll");
var httpContext2 = new HttpContext(IP: "216.239.38.120", Url: "localhost:4040/Product/GetAll");




//US IP----------------
 new PipeBuilder()
    .AddPipe(typeof(ExceptionHandlerPipe))
    .AddPipe(typeof(AuthenticaionPipe))
    .AddPipe(typeof(EndPointPipe))
    .Build(httpContext1);

//Iran IP--------------
new PipeBuilder()
    .AddPipe(typeof(ExceptionHandlerPipe))
    .AddPipe(typeof(AuthenticaionPipe))
    .AddPipe(typeof(EndPointPipe))
    .Build(httpContext2);