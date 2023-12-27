using PipelineDesignPatternExp;

var framework = new Framework();

var ipController = new IpController();

var productsController = new ProductsController();

var httpContext = new HttpContext()
{
    IpAddress = "1.32.232.0",
    Url = "/Products/GetProductById/1"
};

#region Commented

//framework.Authentication(httpContext,
//                (httpContext) => framework.ExceptionHandling(httpContext, ((httpContext) => ipController.GetUserIp(httpContext))));

//framework.ExceptionHandling(httpContext,
//    (httpContext) =>
//framework.Authentication(httpContext,
//    (httpContext) => framework.EndPointHandling(httpContext, null!)));

//var eh = new EndPointHandling(null!);
//var au = new Authentication(eh.Handle);
//var ex = new ExceptionHandling(au.Handle);

//eh.Handle(httpContext);
#endregion


var pipeBuilder = new PipelineBuilder()
                        .AddPipe(typeof(Authentication))
                        .Build(httpContext, (//How can I pass Action to run this method??));

Console.ReadKey();