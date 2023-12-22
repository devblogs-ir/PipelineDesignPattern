using Dumpify;
using PipelineDesignPattern;

ProductController controller = new ProductController();
Framework framework = new Framework();

var httpContext1 = new HttpContext("185.188.104.10");
var httpContext2 = new HttpContext("216.239.38.120");


"US IP----------------------------".Dump();
framework.ExceptionHandling(
    httpContext2, (context) =>
        framework.Authentication(context, controller.GetAllUser)
        );

"Iran IP----------------------------".Dump();
framework.ExceptionHandling(
    httpContext1, (context) =>
        framework.Authentication(context, controller.GetAllUser)
        );

