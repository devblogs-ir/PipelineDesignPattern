using PipelineDesignPattern;

HttpContext httpContext = new() { IP = "85.185.20.177" };
HttpContext httpContextUSA = new() { IP = "102.128.167.255" };

ProductsController productsController = new();
Framework framework = new();

framework.ExceptionHandling(httpContext,
    (context) => framework.Authentication(context,
    (context) => productsController.GetAll(context)));

framework.ExceptionHandling(httpContextUSA,
    (context) => framework.Authentication(context,
    (context) => productsController.GetAll(context)));