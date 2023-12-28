using System.Reflection;
using PipeLineDesignPattern;

HttpContext getAllProductsReq = new()
{
    Ip = "123.185.20.177",
    Url = "localhost:3000/Product/GetAll"
};


new PipeLineBuilder()
    .AddPipe(typeof(ExceptionHandling))
    .AddPipe(typeof(Authentication))
    .AddPipe(typeof(EndPoint))
    .Build(getAllProductsReq);
