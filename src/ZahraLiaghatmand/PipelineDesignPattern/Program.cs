using PipelineDesignPattern;

Framework framework = new();
HttpContext requestGetAllProducts = new() { 
    IP = "123.185.20.177",
    Url = "localhost:4545/Orders/GetAll"
};

framework.ExceptionHandling(requestGetAllProducts,
    (context) => framework.Authentication(context,
    (context) => framework.EndpointHandling(context,null!)));