using PipelineDesignPattern;

HttpContext httpContext = new() { IP = "iran" };
HttpContext httpContextUSA = new() { IP = "usa" };

ProductsController productsController = new();
Framework framework = new();

framework.ExceptionHandling(httpContext,
    (context) => framework.Authentication(context,
    (context) => productsController.GetAll(context)));

framework.ExceptionHandling(httpContextUSA,
    (context) => framework.Authentication(context,
    (context) => productsController.GetAll(context)));