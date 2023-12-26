using PipelineDesignPatternExp;

var framework = new Framework();

var ipController = new IpController();

Console.WriteLine("Enter your Ip: ");

var userIp = Console.ReadLine();

var httpContext = new HttpContext()
{
    IpAddress = userIp
};

framework.Authentication(httpContext,
                (httpContext) => framework.ExceptionHandling(httpContext, ((httpContext) => ipController.GetUserIp(httpContext))));

Console.ReadKey();