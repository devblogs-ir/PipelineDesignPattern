using PipelineDesignPattern;

HttpContext httpContext1 = new() { IP = "Iran"};
HttpContext httpContext2 = new() { IP = "USA"};
HttpContext httpContext3 = new() { IP = "Japan"};

ProductController productController = new();
Framework framework = new();
framework.Authentication(httpContext1,
    (context) => framework.ExceptionHandling(httpContext1,
    productController.GetAllProducts));

framework.Authentication(httpContext2,
    (context) => framework.ExceptionHandling(httpContext2,
    productController.GetAllProducts));

framework.Authentication(httpContext3,
    (context) => framework.ExceptionHandling(httpContext3,
    productController.GetAllProducts));