using PipelineDesignPattern.Controllers;
using PipelineDesignPattern.Framework;

Framework framework = new();
ProductController productController = new();

// Request by USA
HttpContext httpContext2 = new() { IP = "1.55.29.115", Url = "localhost/api/Product/GetAll" };
framework.ExceptionHandeling(httpContext2, (context) => framework.Authentication(context, 
                                           (context) => framework.EndPointHanling(context, null!)));

Console.WriteLine("----------------------------------------");

// Reuqest by Iran
HttpContext httpContext1 = new() { IP = "98.39.10.01", Url = "localhost/api/Product/GetById/2" };
framework.ExceptionHandeling(httpContext1, (context) => framework.Authentication(context, 
                                           (context) => framework.EndPointHanling(context, null!)));
