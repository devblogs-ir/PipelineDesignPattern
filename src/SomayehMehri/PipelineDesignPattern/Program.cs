// See https://aka.ms/new-console-template for more information
using PipelineDesignPattern;

Console.WriteLine("Hello, World!");


ProductController controller = new ProductController();
Framework framework = new();


var httpContext = new HttpContext { Ip = "37.255.130.023" };
var httpContextUSA = new HttpContext { Ip = "2.16.102.255" };




framework.ExceptionHandeling(httpContext, (context) =>
                    framework.Authentication(context, controller.GetUserById));

framework.ExceptionHandeling(httpContextUSA, (context) =>
                    framework.Authentication(context, controller.GetUserById));


