// See https://aka.ms/new-console-template for more information


using PipelineDesignPattern;

ProductController productController = new ();
Framework framework = new ();
var httpContext= new HttpContext() {  IP= "192.15.0.0" };
var httpContext2= new HttpContext() {  IP= "102.129.131.0" };
framework
    .ExceptionHandling(httpContext,(context ) => framework
    .Cors(context, (context) => framework
    .Routing(context, (context) => framework
    .Authentication(context, productController
    .GetAllUser))));
framework
    .ExceptionHandling(httpContext2, (context) => framework
    .Cors(context, (context) => framework
    .Routing(context, (context) => framework
    .Authentication(context, productController
    .GetAllUser))));

public class HttpContext
{
    public string IP { get; set; }
}
