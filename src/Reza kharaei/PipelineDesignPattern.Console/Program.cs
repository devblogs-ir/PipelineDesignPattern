using PipelineDesignPattern.Controllers;

Framework framework = new();
ProductController productController = new();

// Request by USA
HttpContext httpContext2 = new() { IP = "1.55.29.115" };
framework.ExceptionHandeling(httpContext2, (context) => framework.Authentication(context, productController.GetAllProduct));

Console.WriteLine("----------------------------------------");

// Reuqest by Iran
HttpContext httpContext1 = new() { IP = "98.39.10.01" };
framework.ExceptionHandeling(httpContext1, (context) => framework.Authentication(context, productController.GetAllProduct));
