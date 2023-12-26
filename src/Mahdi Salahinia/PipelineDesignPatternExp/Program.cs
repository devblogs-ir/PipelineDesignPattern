using PipelineDesignPatternExp;

var framework = new Framework();

var ipController = new IpController();
var productsController = new ProductsController();

//Console.WriteLine("Enter your Ip: ");

//var userIp = Console.ReadLine();

var httpContext = new HttpContext()
{
    IpAddress = "1.32.232.0",
    Url = "/Products/GetAll"
};

//framework.Authentication(httpContext,
//                (httpContext) => framework.ExceptionHandling(httpContext, ((httpContext) => ipController.GetUserIp(httpContext))));

framework.ExceptionHandling(httpContext,
    (httpContext) =>
framework.Authentication(httpContext,
    (httpContext) => framework.EndPointHandling(httpContext, null!)));

Console.ReadKey();