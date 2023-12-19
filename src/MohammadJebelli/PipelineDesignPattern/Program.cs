using Dumpify;
using PipelineDesignPattern;

ProductController controller = new ProductController();
Framework framework = new Framework();

var httpContext1 = new HttpContext() { IP = "Iran" };
var httpContext2 = new HttpContext() { IP = "US" };


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

