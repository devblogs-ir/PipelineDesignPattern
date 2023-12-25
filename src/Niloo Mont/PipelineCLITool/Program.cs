using PipelineCLITool;

Framework framework = new();

HttpContext GetAllProductsRequest = new()
{
    IP = "Iran",
    Url = "localhost:7777/Products/GetAllProducts"
};
HttpContext GetAllProductsRequest2 = new()
{
    IP = "USA",
    Url = "localhost:7777/Products/GetUserById/2"
};
HttpContext GetAllProductsRequest3 = new()
{
    IP = "USA",
    Url = "localhost:7777/Products/GetAllProducts"
};

framework.AuthenticationHandling(GetAllProductsRequest,
    (context) => framework.ExceptionHandling((context),
    (context) => framework.EndpointHandling(context, null!)));

framework.AuthenticationHandling(GetAllProductsRequest2,
    (context) => framework.ExceptionHandling((context),
    (context) => framework.EndpointHandling(context, null!)));

framework.AuthenticationHandling(GetAllProductsRequest3,
    (context) => framework.ExceptionHandling((context),
    (context) => framework.EndpointHandling(context, null!)));


