// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Http;
using PipelineDesignPattern;


ProductController productController = new ProductController();
Framework framework = new();
HttpContext httpContextIran = new(){ IP = "5.210.184.13" };
HttpContext httpContextUSA = new() { IP = "209.142.68.29" };

framework.ExceptionHandling(httpContextIran, (context) => framework.AuthenticationHandling(context,productController.Print));
framework.ExceptionHandling(httpContextUSA, (context) => framework.AuthenticationHandling(context, productController.Print));





public class HttpContext
{
    public string IP { get; set; }
}