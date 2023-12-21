using PipelineDesignPatternExp;

var framework = new Framework();
var ipController = new IpController();

Console.WriteLine("Enter your Ip: ");
var ip = Console.ReadLine();

var httpContext = new HttpContext()
{
    IpAddress = ip
};


framework.Authentication(httpContext,
                (httpContext) => framework.ExceptionHandling(httpContext, ((httpContext) => ipController.GetMyIp(httpContext))));

Console.ReadKey();